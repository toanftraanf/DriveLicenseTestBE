using DriverLicenseTestBE.Models;
using DriverLicenseTestBE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DriverLicenseTestBE.Services
{
    public interface IQuestionService
    {
        public string CreateQuestion(InsertQuestionVM question);
        public string GetQuestionById(int id, out dynamic question);
        public string GetAllQuestions(out dynamic questionsResult);
        public string UpdateQuestion(UpdateQuestionVM question);
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
        public string GetQuestionById(int id, out dynamic question)
        {
            question = _context.Questions
                        .Include(q => q.Answers)
                        .Select(q => new
                        {
                            q.QuestionId,
                            q.Content,
                            Answers = q.Answers.Select(a => new
                            {
                                a.AnswerId,
                                a.AnswerText,
                                a.IsCorrect,
                                a.CreatedAt
                            }).ToList(),
                            q.CreatedAt
                        })
                        .FirstOrDefault(q => q.QuestionId == id);
            if (question == null) return "Not found";
            return "";
        }

        public string GetAllQuestions(out dynamic questionsResult)
        {
            questionsResult = _context.Questions.Any() ? _context.Questions.ToList() : null;
            return questionsResult == null ? "There are no questions" : "";
        }

        // Update
        public string UpdateQuestion(UpdateQuestionVM question)
        {
            try
            {
                // Find the existing question
                var existingQuestion = _context.Questions
                    .Include(q => q.Answers)
                    .FirstOrDefault(q => q.QuestionId == question.QuestionId);

                if (existingQuestion == null)
                {
                    return "Question not found";
                }

                // Check empty answer
                if (question.Answers == null || question.Answers.Count == 0)
                {
                    return "Answers are required";
                }

                // Update the question content
                existingQuestion.Content = question.Content;

                // Compare the answers and update accordingly
                var newAnswers = question.Answers
                    .Select(a => new Answer
                    {
                        AnswerId = a.AnswerId,
                        AnswerText = a.AnswerText,
                        IsCorrect = a.IsCorrect
                    })
                    .ToList();

                var existingAnswers = existingQuestion.Answers.ToList();

                // Remove old answers
                _context.Answers.RemoveRange(existingAnswers);

                // Add new answers
                _context.Answers.AddRange(
                    newAnswers
                    .Select(a => new Answer
                    {
                        AnswerText = a.AnswerText,
                        IsCorrect = a.IsCorrect,
                        QuestionId = existingQuestion.QuestionId
                    }).ToList());

                // Save the changes
                _context.Questions.Update(existingQuestion);
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
