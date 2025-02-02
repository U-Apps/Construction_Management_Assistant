namespace ConstructionManagementAssistant_Core.DTOs
{
    public class GetWorkerSpecialtyDto
    {
        public int Id { get; init; }
        public string SpecialtyName { get; init; }
    }

    public class AddWorkerSpecialtyDto
    {
        public required string SpecialtyName { get; init; }
    }

    public class UpdateWorkerSpecialtyDto
    {
        public required int Id { get; init; }
        public required string SpecialtyName { get; init; }
    }
}
