CREATE PROCEDURE [dbo].[spTasks_Insert]
	@Name nvarchar(50),
	@Description nvarchar(100),
	@Priority tinyint,
	@StartDate datetime2(7),
	@EndDate datetime2(7),
	@TaskGroupId int
AS
begin
	insert into dbo.Tasks(Name, Description, Priority, StartDate, EndDate, TaskGroupId)
	output inserted.[Id]
	values (@Name, @Description, @Priority, @StartDate, @EndDate, @TaskGroupId)
end