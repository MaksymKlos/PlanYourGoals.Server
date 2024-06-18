namespace PlanYourGoals.Server.Web.Api.Models.DTOs.Project;

public class PlanningProjectDTO
{
    public required int Id { get; set; }

    public required string Name { get; set; } = string.Empty;

    public int UserId { get; set; }
}