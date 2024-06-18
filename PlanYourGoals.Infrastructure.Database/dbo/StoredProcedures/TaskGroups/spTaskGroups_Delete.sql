CREATE PROCEDURE [dbo].[spTaskGroups_Delete]
	@Id int
AS
begin
	begin try

		begin transaction;

		--Delete tasks related to taskGroup--
		delete
		from dbo.Tasks
		where TaskGroupId = @Id;

		--Delete Task Group--
		delete
		from dbo.TaskGroups
		where Id = @Id;

		commit transaction;

	end try
	begin catch
		if @@TRANCOUNT > 0
			rollback transaction;
		throw;
	end catch;
end;