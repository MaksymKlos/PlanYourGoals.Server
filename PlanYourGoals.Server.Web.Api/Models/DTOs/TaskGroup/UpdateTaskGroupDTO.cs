namespace PlanYourGoals.Server.Web.Api.Models.DTOs.TaskGroup;

public class UpdateTaskGroupDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}