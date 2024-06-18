using AutoMapper;
using PlanYourGoals.Server.Application.Services.Models;
using PlanYourGoals.Server.Common.Core.Models;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Achievements;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Project;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Task;
using PlanYourGoals.Server.Web.Api.Models.DTOs.TaskGroup;
using PlanYourGoals.Server.Web.Api.Models.DTOs.User;
using System.Globalization;

namespace PlanYourGoals.Server.Web.Api.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateUserMapping();
        CreatePlanningProjectMapping();
        CreateTaskGroupMapping();
        CreateTaskMapping();
        CreateAchievementMapping();
    }

    private void CreateUserMapping()
    {
        CreateMap<UserRegistrationRequestDTO, NewIdentityUser>();
        CreateMap<UserRegistrationRequestDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
    }

    private void CreatePlanningProjectMapping()
    {
        CreateMap<PlanningProject, PlanningProjectDTO>();
        CreateMap<PlanningProjectDTO, PlanningProject>();
        CreateMap<CreatePlanningProjectDTO, PlanningProject>();
        CreateMap<UpdatePlanningProjectDTO, PlanningProject>();
    }

    private void CreateTaskGroupMapping()
    {
        CreateMap<TaskGroup, TaskGroupDTO>();
        CreateMap<TaskGroupDTO, TaskGroup>();
        CreateMap<CreateTaskGroupDTO, TaskGroup>();
        CreateMap<UpdateTaskGroupDTO, TaskGroup>();
    }

    private void CreateTaskMapping()
    {
        CreateMap<TaskModel, TaskModelDTO>();
        CreateMap<TaskModelDTO, TaskModel>();
        CreateMap<CreateTaskModelDTO, TaskModel>();
        CreateMap<UpdateTaskModelDTO, TaskModel>();
    }

    private void CreateAchievementMapping()
    {
        CreateMap<CreateAchievementDTO, Achievement>();
        CreateMap<AchievementDTO, Achievement>();
        CreateMap<Achievement, AchievementDTO>();
    }
}