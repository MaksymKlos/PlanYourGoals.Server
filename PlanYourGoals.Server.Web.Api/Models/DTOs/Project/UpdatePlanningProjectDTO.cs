namespace PlanYourGoals.Server.Web.Api.Models.DTOs.Project;

public class UpdatePlanningProjectDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
}