namespace ConstructionManagementAssistant_Core.Helper;


// This class is used to store all the API routes in one place so that we can easily access them.
public static class SystemApiRouts

{
    public static class Client
    {
        public const string Base = "api/v1/Clients";
        public const string GetClientById = Base + "/{Id}";
        public const string GetAllCleint = Base;
        public const string AddClient = Base;
        public const string UpdateClient = Base;
        public const string DeleteClient = Base + "/{Id}";
    }

    public static class SiteEngineer
    {
        public const string Base = "api/v1/SiteEngineers";
        public const string GetSiteEngineerById = Base + "/{Id}";
        public const string GetAllSiteEngineer = Base;
        public const string AddSiteEngineer = Base;
        public const string UpdateSiteEngineer = Base;
        public const string DeleteSiteEngineer = Base + "/{Id}";
    }

    public class WorkerSpecialty
    {
        public const string Base = "api/v1/WorkerSpecialties";
        public const string GetWorkerSpecialtyById = Base + "/{Id}";
        public const string GetAllWorkerSpecialties = Base;
        public const string AddWorkerSpecialty = Base;
        public const string UpdateWorkerSpecialty = Base;
        public const string DeleteWorkerSpecialty = Base + "/{Id}";

    }

    public class Worker
    {
        public const string Base = "api/v1/Workers";
        public const string GetWorkerById = Base + "/{Id}";
        public const string GetAllWorkers = Base;
        public const string AddWorker = Base;
        public const string UpdateWorker = Base;
        public const string DeleteWorker = Base + "/{Id}";
    }

    public static class Project
    {
        public const string Base = "api/v1/Projects";
        public const string GetProjectById = Base + "/{Id}";
        public const string GetAllProjects = Base;
        public const string AddProject = Base;
        public const string UpdateProject = Base;
        public const string DeleteProject = Base + "/{Id}";
        public const string GetAllCompletedProjects = Base + "/Completed";
        public const string GetAllCancelProjects = Base + "/Cancelled";
        public const string GetUnderImplementingProjects = Base + "/UnderImplementing";
        public const string CompleteProject = Base + "/Complete/{Id}";
        public const string CancelProject = Base + "/Cancel/{Id}";
        public const string AssignProjectToSiteEngineer = Base + "/AssignToSiteEngineer";
    }

}
