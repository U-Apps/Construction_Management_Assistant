namespace ConstructionManagementAssistant.Core.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }


        //[Required]
        //public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }



        //[Required]
        //public SystemRole role { get; set; }  // BY DEFAULT ADMIN 
    }
}

