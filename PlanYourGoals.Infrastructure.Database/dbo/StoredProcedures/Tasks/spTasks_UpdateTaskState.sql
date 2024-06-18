CREATE PROCEDURE [dbo].[spTasks_UpdateTaskState]
	@Id int,
	@IsCompleted bit
AS
begin
	begin try

		begin transaction;

		declare @WasCompleted bit, @UserId int
		
		-- Get the previous state of the task and its associated user ID
		select @WasCompleted = IsCompleted, @UserId = UserId
		from dbo.Tasks as task
		INNER JOIN dbo.TaskGroups as taskGroup on task.TaskGroupId = taskGroup.Id
		INNER JOIN dbo.PlanningProjects as project on taskGroup.ProjectId = project.Id
		where task.Id = @Id;

		-- update task state
		update dbo.Tasks
		set IsCompleted = @IsCompleted
		where Id = @Id

		--update count of user's completed tasks
		if (@WasCompleted = 0 AND @IsCompleted = 1) -- add 1 to CompletedTasks if user complete one
		begin
			update dbo.Users
			set CompletedTasks += 1
			where Id = @UserId;
		end
		else if (@WasCompleted = 1 AND @IsCompleted = 0) -- substract 1 of CompletedTasks if user uncomplete one
		begin
			update dbo.Users
			set CompletedTasks -= 1
			where Id = @UserId;
		end;

		commit transaction;

	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback transaction;
		throw;
	end catch;
end;