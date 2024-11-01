using DriverLicenseTestBE.Services;
using DriverLicenseTestBE.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DriverLicenseTestBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("CreateQuestion")]
        public IActionResult CreateQuestion(InsertQuestionVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string msg = _questionService.CreateQuestion(model);
            if (msg.Length > 0) return BadRequest(msg);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionById(int id)
        {
            string msg = _questionService.GetQuestionById(id, out object question);
            if (msg.Length > 0) return BadRequest(msg);

            return Ok(question);
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            string msg = _questionService.GetAllQuestions(out object questionsResult);
            if (msg.Length > 0) return BadRequest(msg);
            return Ok(questionsResult);
        }

        [HttpPut("UpdateQuestion")]
        public IActionResult UpdateQuestion(UpdateQuestionVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string msg = _questionService.UpdateQuestion(model);
            if (msg.Length > 0) return BadRequest(msg);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            string msg = _questionService.DeleteQuestion(id);
            if (msg.Length > 0) return BadRequest(msg);

            return Ok();
        }
    }
}
