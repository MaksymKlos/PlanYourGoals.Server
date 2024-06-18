using PlanYourGoals.Infrastructure.DataAccess.Interfaces.Data;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;

namespace PlanYourGoals.Server.Application.Services.Services;

public class PlanningProjectService(ICommonData<PlanningProject> projectsData) : IPlanningProjectService
{
    public async Task<List<PlanningProject>> GetAllAsync(int userId)
    {
        var projects = await projectsData.GetAllAsync(userId);

        return projects.ToList();
    }

    public async Task<PlanningProject> CreateAsync(PlanningProject project)
    {
        var id = await projectsData.InsertAsync(project);
        project.Id = id;

        return project;
    }

    public async Task<PlanningProject> UpdateAsync(PlanningProject project)
    {
        await projectsData.UpdateAsync(project);

        return project;
    }

    public async Task DeleteAsync(int id)
    {
        await projectsData.DeleteAsync(id);
    }
}