namespace ConstructionManagementAssistant.Core.Helper;


// This class is used to store all the API routes in one place so that we can easily access them.
public static class SystemApiRouts

{
    public static class Clients
    {
        public const string Base = "api/v1/Clients";
        public const string GetClientById = Base + "/{Id}";
        public const string GetAllCleint = Base;
        public const string AddClient = Base;
        public const string UpdateClient = Base;
        public const string DeleteClient = Base + "/{Id}";
        public const string GetClientNames = Base + "/Names";

    }

    public static class SiteEngineers
    {
        public const string Base = "api/v1/SiteEngineers";
        public const string GetSiteEngineerById = Base + "/{Id}";
        public const string GetAllSiteEngineer = Base;
        public const string AddSiteEngineer = Base;
        public const string UpdateSiteEngineer = Base;
        public const string DeleteSiteEngineer = Base + "/{Id}";
        public const string GetSiteEngineerNames = Base + "/Names";

    }

    public class WorkerSpecialties
    {
        public const string Base = "api/v1/WorkerSpecialties";
        public const string GetWorkerSpecialtyById = Base + "/{Id}";
        public const string GetAllWorkerSpecialties = Base;
        public const string AddWorkerSpecialty = Base;
        public const string UpdateWorkerSpecialty = Base;
        public const string DeleteWorkerSpecialty = Base + "/{Id}";

    }

    public class Workers
    {
        public const string Base = "api/v1/Workers";
        public const string GetWorkerById = Base + "/{Id}";
        public const string GetAllWorkers = Base;
        public const string AddWorker = Base;
        public const string UpdateWorker = Base;
        public const string DeleteWorker = Base + "/{Id}";
        public const string GetWorkerNames = Base + "/Names";

    }

    public static class Projects
    {
        public const string Base = "api/v1/Projects";
        public const string GetProjectById = Base + "/{id}";
        public const string GetAllProjects = Base;
        public const string GetAllProjectNames = Base + "/GetAllProjectNames";

        public const string AddProject = Base;
        public const string UpdateProject = Base;
        public const string DeleteProject = Base + "/{id}";
        public const string GetAllCompletedProjects = Base + "/Completed";
        public const string GetAllCancelProjects = Base + "/Cancelled";
        public const string GetUnderImplementingProjects = Base + "/UnderImplementing";
        public const string CompleteProject = Base + "/Complete/{id}";
        public const string CancelProject = Base + "/Cancel/{id}";
        public const string AssignProjectToSiteEngineer = Base + "/AssignToSiteEngineer";
    }

    public class Stages
    {
        public const string Base = "api/v1/Stages";
        public const string AddStage = Base;
        public const string GetAllStages = Base;
        public const string GetStageById = Base + "/{Id}";
        public const string UpdateStage = Base;
        public const string DeleteStage = Base + "/{Id}";
    }

    public static class Equipment
    {
        public const string Base = "api/v1/Equipment";
        public const string GetAllEquipment = Base;
        public const string GetEquipmentById = Base + "/{id}";
        public const string AddEquipment = Base;
        public const string UpdateEquipment = Base;
        public const string SetStatus = Base + "/SetStatus";
        public const string DeleteEquipment = Base + "/{id}";
    }

    public static class EquipmentAssignments
    {
        public const string Base = "api/v1/EquipmentAssignments";
        public const string Assign = Base + "/Assign";
        public const string Unassign = Base + "/Unassign/{assignmentId}";
        public const string GetByEquipment = Base + "/ByEquipment/{equipmentId}";
        public const string GetByProject = Base + "/ByProject/{projectId}";
    }

    public static class Tasks
    {
        public const string Base = "api/v1/Tasks";
        public const string GetTaskById = Base + "/{Id}";
        public const string GetAllTasks = Base;
        public const string AddTask = Base;
        public const string UpdateTask = Base;
        public const string DeleteTask = Base + "/{Id}";
        public const string CompleteTask = Base + "/CompleteTask/{Id}";
        public const string UnCheckTask = Base + "/UnCheckTask/{Id}";
        public const string AssignWorkersToTask = Base + "/AssignWorkersToTask";
    }

    public static class TaskAssignments
    {
        public const string Base = "api/v1/TaskAssignments";
        public const string GetByTaskId = Base + "/ByTask/{taskId}";
        public const string GetByWorkerId = Base + "/ByWorker/{workerId}";
        public const string AssignWorkersToTask = Base + "/AssignWorkersToTask";
        public const string UnAssignWorkersToTask = "api/task-assignments/unassign";


    }

}
