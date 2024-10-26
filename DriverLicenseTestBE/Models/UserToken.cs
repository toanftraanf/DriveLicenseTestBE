using System;
using System.Collections.Generic;

namespace DriverLicenseTestBE.Models
{
    public partial class UserToken
    {
        public int Id { get; set; }
        public bool? IsRememberPassword { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
