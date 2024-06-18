namespace PlanYourGoals.Infrastructure.DataAccess.Constants;

public class StoredProcedures
{
    //IdentityUsers
    public const string InsertIdentityUser = "spIdentityUsers_Insert";
    public const string UpdateIdentityUser = "spIdentityUsers_Update";
    public const string GetIdentityUser = "spIdentityUsers_GetByEmail";

    //Users
    public const string InsertUser = "spUsers_Insert";
    public const string UpdateUser = "spUsers_Update";
    public const string GetUserByEmail = "spUsers_GetByEmail";

    //PlaningProjects
    public const string GetAllProjects = "spPlanningProjects_GetAll";
    public const string InsertProject = "spPlanningProjects_Insert";
    public const string UpdateProject = "spPlanningProjects_Update";
    public const string DeleteProject = "spPlanningProjects_Delete";

    //TaskGroups
    public const string GetAllTaskGroups = "spTaskGroups_GetAll";
    public const string InsertTaskGroup = "spTaskGroups_Insert";
    public const string UpdateTaskGroup = "spTaskGroups_Update";
    public const string DeleteTaskGroup = "spTaskGroups_Delete";

    //Tasks
    public const string GetAllTasks = "spTasks_GetAll";
    public const string GetAllTasksByUserId = "spTasks_GetAllByUserId";
    public const string InsertTask = "spTasks_Insert";
    public const string UpdateTask = "spTasks_Update";
    public const string DeleteTask = "spTasks_Delete";
    public const string UpdateTaskState = "spTasks_UpdateTaskState";

    //Achievements
    public const string GetAllAchievements = "spAchievements_GetAll";
    public const string InsertAchievement = "spAchievements_Insert";
    public const string UpdateAchievement = "spAchievements_Update";
    public const string DeleteAchievement = "spAchievements_Delete";
}