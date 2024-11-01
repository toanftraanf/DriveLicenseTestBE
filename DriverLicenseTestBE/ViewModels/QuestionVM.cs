using System.ComponentModel.DataAnnotations;

namespace DriverLicenseTestBE.ViewModels
{
    public class QuestionVM
    {
    }
    public class InsertQuestionVM
    {
        //public int QuestionId { get; set; }
        [Required]
        public string Content { get; set; } = null!;
        [Required]
        public List<InsertAnswerVM> Answers { get; set; }
    }
    public class InsertAnswerVM
    {
        //public int AnswerId { get; set; }
        [Required]
        public string AnswerText { get; set; } = null!;
        public bool IsCorrect { get; set; } = false;
    }
}
