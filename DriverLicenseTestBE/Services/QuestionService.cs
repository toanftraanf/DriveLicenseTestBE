using DriverLicenseTestBE.Models;
using DriverLicenseTestBE.ViewModels;

namespace DriverLicenseTestBE.Services
{
    public interface IQuestionService
    {
        public string CreateQuestion(InsertQuestionVM question);
        public string GetQuestionById(int id, out Question question);
        public string GetAllQuestions(out dynamic questionsResult);
        public string UpdateQuestion(Question question);
        public string DeleteQuestion(int id);
    }
    public class QuestionService : IQuestionService
    {
        private readonly DriverLicenseTestContext _context;

        public QuestionService(DriverLicenseTestContext context)
        {
            _context = context;
        }

        // Create
        public string CreateQuestion(InsertQuestionVM question)
        {
            try
            {
                if (question.Answers == null || question.Answers.Count == 0)
                {
                    return "Answers are required";
                }
                Question newQuestion = new Question
                {
                    Content = question.Content,
                    Answers = question.Answers
                    .Select(a => new Answer
                    {
                        AnswerText = a.AnswerText,
                        IsCorrect = a.IsCorrect
                    }).ToList(),
                };
                _context.Questions.Add(newQuestion);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        // Read
        public string GetQuestionById(int id, out Question question)
        {
            question = _context.Questions.Find(id);
            if (question == null) return "Not found";
            return "";
        }

        public string GetAllQuestions(out dynamic questionsResult)
        {
            questionsResult = _context.Questions.Any() ? _context.Questions.ToList() : null;
            return questionsResult == null ? "There are no questions" : "";
        }

        // Update
        public string UpdateQuestion(Question question)
        {
            try
            {
                _context.Questions.Update(question);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        // Delete
        public string DeleteQuestion(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                try
                {
                    _context.Questions.Remove(question);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }
    }
}
