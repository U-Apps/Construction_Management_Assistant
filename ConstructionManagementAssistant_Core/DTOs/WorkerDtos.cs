using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant_Core.DTOs
{
    public class AddWorkerDto
    {
        public required string FirstName { get; init; }
        public required string SecondName { get; init; }
        public string? ThirdName { get; init; }
        public required string LastName { get; init; }
        [MaxLength(15)]
        public string? NationalNumber { get; init; }
        [Phone]
        public string? PhoneNumber { get; init; }
        [EmailAddress]
        public string? Email { get; init; }
        public string? Address { get; init; }
        public int? SpecialtyId { get; init; }
    }

    public class GetWorkerDto
    {
        public int Id { get; init; }
        public required string FullName { get; init; }
        public string Specialty { get; init; }
        public bool IsAvailable { get; init; }
    }

    public class UpdateWorkerDto
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; }
        public required string SecondName { get; init; }
        public string? ThirdName { get; init; }
        public required string LastName { get; init; }
        [MaxLength(15)]
        public string? NationalNumber { get; init; }
        [Phone]
        public string? PhoneNumber { get; init; }
        [EmailAddress]
        public string? Email { get; init; }
        public string? Address { get; init; }
        public int? SpecialtyId { get; init; }
    }
}