using System;
using System.Collections.Generic;

namespace DriverLicenseTestBE.Models
{
    public partial class User
    {
        public User()
        {
            Notifications = new HashSet<Notification>();
            Tests = new HashSet<Test>();
            UserNotifies = new HashSet<UserNotify>();
            UserTokens = new HashSet<UserToken>();
            Roles = new HashSet<Role>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<UserNotify> UserNotifies { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
