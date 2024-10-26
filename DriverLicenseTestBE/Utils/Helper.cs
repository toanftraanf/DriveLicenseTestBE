using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace DriverLicenseTestBE.Utils
{
    public static class Helper
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public static bool IsValid(this object obj, out List<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            if (obj == null) return false;
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
        public static bool IsValid(this object obj, out string results)
        {
            results = "";
            if (obj == null) { results = "Object is null"; return false; }
            var listErr = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, new ValidationContext(obj), listErr, true);
            if (!isValid) results = listErr.First().ErrorMessage;
            return isValid;
        }
    }
}
