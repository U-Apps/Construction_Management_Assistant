namespace ConstructionManagementAssistant.Core.DTOs
{
    public class AddWorkerDto
    {
        public required string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public required string LastName { get; init; }
        [MaxLength(15)]
        public string? NationalNumber { get; init; }

        [Phone]
        public required string PhoneNumber { get; init; }

        [EmailAddress]
        public string? Email { get; init; }
        public string? Address { get; init; }
        public int? SpecialtyId { get; init; }
    }

    public class GetWorkerDto
    {
        public int Id { get; init; }
        public required string FullName { get; init; }
        public string? Specialty { get; init; }
        public bool IsAvailable { get; init; }
    }

    public class WorkerDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NationalNumber { get; set; }
        public string? Address { get; set; }
        public string? Specialty { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<TaskNameDto> Tasks { get; set; }

    }


    public class UpdateWorkerDto
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string? ThirdName { get; init; }
        public required string LastName { get; init; }

        [MaxLength(15)]
        public string? NationalNumber { get; init; }

        [Phone]
        public required string PhoneNumber { get; init; }

        [EmailAddress]
        public string? Email { get; init; }
        public string? Address { get; init; }
        public int? SpecialtyId { get; init; }
    }

}