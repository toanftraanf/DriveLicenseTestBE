using System.ComponentModel.DataAnnotations;

namespace DriverLicenseTestBE.ViewModels
{
    public class UserVM
    {
    }

    public class UserLoginVM
    {
        [Required(ErrorMessage = "Username/Email is required")]
        //[RegularExpression(@"^[a-zA-Z0-9]{3,15}$", ErrorMessage = "Username must be alphanumeric and 3-15 characters long")]
        public string Username { get; set; } = null!;

        //[Required(ErrorMessage = "Email is required")]
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is not valid")]
        //public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{6,}$", ErrorMessage = "Password must have at least 6 characters and be alphanumeric")]
        public string Password { get; set; } = null!;
    }

    public class UserRegisterVM
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9]{3,15}$", ErrorMessage = "Username must be alphanumeric and 3-15 characters long")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{6,}$", ErrorMessage = "Password must have at least 6 characters and be alphanumeric")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Full Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full Name must contain only letters and spaces")]
        [StringLength(50, ErrorMessage = "Full Name cannot exceed 50 characters")]
        public string FullName { get; set; } = string.Empty;
    }
}
