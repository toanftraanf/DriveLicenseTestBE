using System;
using System.Collections.Generic;

namespace DriverLicenseTestBE.Models
{
    public partial class Answer
    {
        public Answer()
        {
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; } = null!;
        public bool IsCorrect { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
