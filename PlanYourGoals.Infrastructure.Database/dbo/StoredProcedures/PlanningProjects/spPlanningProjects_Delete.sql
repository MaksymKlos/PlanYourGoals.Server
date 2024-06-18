CREATE PROCEDURE [dbo].[spPlanningProjects_Delete]
	@Id int
AS
begin
	begin try

		begin transaction;

		--Delete tasks related to project--
		delete
		from dbo.Tasks
		where TaskGroupId IN (select Id from dbo.TaskGroups where ProjectId = @Id);

		--Delete all task groups related to project--
		delete
		from dbo.TaskGroups
		where ProjectId = @Id;

		--Delete project--
		delete
		from dbo.PlanningProjects
		where Id = @Id;

		commit transaction;

	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback transaction;
		throw;
	end catch;
end;