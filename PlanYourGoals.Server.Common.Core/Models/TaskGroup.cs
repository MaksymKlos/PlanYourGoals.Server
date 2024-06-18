namespace PlanYourGoals.Server.Common.Core.Models;

public class TaskGroup
{
    public int? Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}