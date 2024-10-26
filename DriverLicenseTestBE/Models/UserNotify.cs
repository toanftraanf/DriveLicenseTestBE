using System;
using System.Collections.Generic;

namespace DriverLicenseTestBE.Models
{
    public partial class UserNotify
    {
        public int NotifyId { get; set; }
        public int UserId { get; set; }
        public bool IsSeen { get; set; }
        public bool IsRead { get; set; }
        public bool IsDelete { get; set; }
        public bool IsCheck { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
