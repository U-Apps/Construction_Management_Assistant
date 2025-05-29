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
            logger.LogInformation("Assigning workers to task. TaskId: {TaskId}, WorkerIds: {WorkerIds}", taskId, string.Join(",", workerIds));
            try
            {
                var task = await _context.Tasks
                    .Include(t => t.TaskAssignments)
                    .FirstOrDefaultAsync(t => t.Id == taskId);

                if (task == null)
                {
                    logger.LogWarning("Task with ID: {TaskId} not found for assignment", taskId);
                    return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };
                }

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
                {
                    logger.LogWarning("All workers are already assigned to task {TaskId}", taskId);
                    return new BaseResponse<string> { Success = false, Message = "جميع العمال محددون بالفعل لهذه المهمة" };
                }

                await _context.TaskAssignments.AddRangeAsync(newAssignments);
                await _context.SaveChangesAsync();

                logger.LogInformation("Assigned {Count} workers to task {TaskId}", newAssignments.Count, taskId);

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم تعيين العمال للمهمة بنجاح"
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error assigning workers to task {TaskId}", taskId);
                throw;
            }
        }

        public async Task<BaseResponse<string>> UnAssignWorkersToTask(int taskId, List<int> workerIds)
        {
            logger.LogInformation("Unassigning workers from task. TaskId: {TaskId}, WorkerIds: {WorkerIds}", taskId, string.Join(",", workerIds));
            try
            {
                var task = await _context.Tasks
                    .Include(t => t.TaskAssignments)
                    .FirstOrDefaultAsync(t => t.Id == taskId);

                if (task == null)
                {
                    logger.LogWarning("Task with ID: {TaskId} not found for unassignment", taskId);
                    return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };
                }

                var assignmentsToRemove = task.TaskAssignments
                    .Where(ta => workerIds.Contains(ta.WorkerId))
                    .ToList();

                if (assignmentsToRemove.Count == 0)
                {
                    logger.LogWarning("No matching workers found for unassignment from task {TaskId}", taskId);
                    return new BaseResponse<string> { Success = false, Message = "لم يتم العثور على أي عمال محددين لهذه المهمة" };
                }

                _context.TaskAssignments.RemoveRange(assignmentsToRemove);
                await _context.SaveChangesAsync();

                logger.LogInformation("Unassigned {Count} workers from task {TaskId}", assignmentsToRemove.Count, taskId);

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم إلغاء تعيين العمال من المهمة بنجاح"
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error unassigning workers from task {TaskId}", taskId);
                throw;
            }
        }

        public async Task<IEnumerable<GetTaskAssignmentDto>> GetAssignmentsByTaskId(int taskId)
        {
            logger.LogInformation("Fetching assignments for taskId: {TaskId}", taskId);
            try
            {
                var result = await GetAllDataWithSelectionAsync(
                    orderBy: x => x.AssignedDate,
                    selector: TaskAssignmentProfile.ToGetTaskAssignmentDto(),
                    criteria: x => x.TaskId == taskId
                );
                logger.LogInformation("Fetched {Count} assignments for taskId: {TaskId}", result.Count, taskId);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching assignments for taskId: {TaskId}", taskId);
                throw;
            }
        }

        public async Task<IEnumerable<GetTaskAssignmentDto>> GetAssignmentsByWorkerId(int workerId)
        {
            logger.LogInformation("Fetching assignments for workerId: {WorkerId}", workerId);
            try
            {
                var result = await GetAllDataWithSelectionAsync(
                    orderBy: x => x.AssignedDate,
                    selector: TaskAssignmentProfile.ToGetTaskAssignmentDto(),
                    criteria: x => x.WorkerId == workerId
                );
                logger.LogInformation("Fetched {Count} assignments for workerId: {WorkerId}", result.Count, workerId);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching assignments for workerId: {WorkerId}", workerId);
                throw;
            }
        }
    }
}
