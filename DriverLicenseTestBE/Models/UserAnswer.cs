using System;
using System.Collections.Generic;

namespace DriverLicenseTestBE.Models
{
    public partial class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Answer Answer { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
        public virtual Test Test { get; set; } = null!;
    }
}
