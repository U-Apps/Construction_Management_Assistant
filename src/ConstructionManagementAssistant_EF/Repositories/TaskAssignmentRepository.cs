namespace ConstructionManagementAssistant.EF.Repositories
{
    public class TaskAssignmentRepository : BaseRepository<TaskAssignment>, ITaskAssignmentRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TaskAssignmentRepository> logger;

        public TaskAssignmentRepository(AppDbContext context, ILogger<TaskAssignmentRepository> logger) : base(context)
        {
            _context = context;
            this.logger = logger;
        }

        public async Task<BaseResponse<string>> AssignWorkersToTask(int taskId, List<int> workerIds)
        {
            var task = await _context.Tasks
                .Include(t => t.TaskAssignments)
                .FirstOrDefaultAsync(t => t.Id == taskId);

            if (task == null)
                return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };

            var existingWorkerIds = task.TaskAssignments
                .Select(ta => ta.WorkerId)
                .ToHashSet();

            var newAssignments = workerIds
                .Where(workerId => !existingWorkerIds.Contains(workerId))
                .Select(workerId => new TaskAssignment
                {
                    TaskId = taskId,
                    WorkerId = workerId,
                    AssignedDate = DateOnly.FromDateTime(DateTime.Now)
                })
                .ToList();

            if (newAssignments.Count == 0)
                return new BaseResponse<string> { Success = false, Message = "جميع العمال محددون بالفعل لهذه المهمة" };

            await _context.TaskAssignments.AddRangeAsync(newAssignments);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تعيين العمال للمهمة بنجاح"
            };
        }


        public async Task<IEnumerable<GetTaskAssignmentDto>> GetAssignmentsByTaskId(int taskId)
        {
            return await GetAllDataWithSelectionAsync(
                orderBy: x => x.AssignedDate,
                selector: TaskAssignmentProfile.ToGetTaskAssignmentDto(),
                criteria: x => x.TaskId == taskId
            );
        }

        public async Task<IEnumerable<GetTaskAssignmentDto>> GetAssignmentsByWorkerId(int workerId)
        {
            return await GetAllDataWithSelectionAsync(
                orderBy: x => x.AssignedDate,
                selector: TaskAssignmentProfile.ToGetTaskAssignmentDto(),
                criteria: x => x.WorkerId == workerId
            );
        }
    }
}
