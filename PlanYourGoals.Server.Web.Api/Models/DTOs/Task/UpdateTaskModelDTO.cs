using PlanYourGoals.Server.Common.Core.Enums;

namespace PlanYourGoals.Server.Web.Api.Models.DTOs.Task;

public class UpdateTaskModelDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public required Priority Priority { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}