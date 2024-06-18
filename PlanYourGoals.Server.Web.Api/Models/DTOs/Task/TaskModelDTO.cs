using PlanYourGoals.Server.Common.Core.Enums;

namespace PlanYourGoals.Server.Web.Api.Models.DTOs.Task;

public class TaskModelDTO
{
    public required int Id { get; set; }
    public required int TaskGroupId { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public required Priority Priority { get; set; }
    public bool IsCompleted { get; set; }
    public required string StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}