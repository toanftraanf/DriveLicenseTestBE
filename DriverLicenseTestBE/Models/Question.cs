using System;
using System.Collections.Generic;

namespace DriverLicenseTestBE.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int QuestionId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
