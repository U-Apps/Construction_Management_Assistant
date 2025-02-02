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
        public const string AddWorker = Base + "/Register";
        public const string GetAllWorkers = Base;
        public const string UpdateWorker = Base;
        public const string DeleteWorker = Base;
        public const string GetWorkerById = Base + "/{Id}";
    }

}
