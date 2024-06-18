using PlanYourGoals.Server.Common.Core.Enums;

namespace PlanYourGoals.Server.Common.Core.Models;

public class TaskModel
{
    public int? Id { get; set; }
    public int TaskGroupId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}