using System;
using System.Collections.Generic;

namespace DriverLicenseTestBE.Models
{
    public partial class Test
    {
        public Test()
        {
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int TestId { get; set; }
        public int UserId { get; set; }
        public DateTime? TestDate { get; set; }
        public int? Score { get; set; }
        public int TotalQuestions { get; set; }
        public int TestTime { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
