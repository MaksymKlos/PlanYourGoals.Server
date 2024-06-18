namespace PlanYourGoals.Server.Web.Api.Models.DTOs.TaskGroup;

public class TaskGroupDTO
{
    public required int Id { get; set; }
    public required int ProjectId { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}