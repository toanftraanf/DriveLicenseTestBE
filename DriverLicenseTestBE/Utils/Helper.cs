using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
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

        public static string SendEmail(string To, string Subject, string Body)
        {
            //var email = new MimeMessage();
            //email.From.Add(new MailboxAddress("Driver", "tranthetoan2003@gmail.com"));
            //email.To.Add(MailboxAddress.Parse(To));
            //email.Subject = Subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = Body };

            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("30b6843919047d", "ffa79f5996e739"),
                EnableSsl = true
            };
            //finally { smtp.Disconnect(true); }
            client.Send("tranthetoan2003@gmail.com", To, Subject, Body);

            return "";
        }

        public static string StringToMD5(string s, out string value)
        {
            string text = "";
            value = null;
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(s);
                return BytesToMD5(bytes, out value);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static string BytesToMD5(byte[] bytes, out string value)
        {
            string result = "";
            value = null;
            try
            {
                MD5 mD = MD5.Create();
                byte[] array = mD.ComputeHash(bytes);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    stringBuilder.Append(array[i].ToString("X2"));
                }

                value = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }
    }
}
