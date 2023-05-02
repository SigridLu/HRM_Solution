using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interview_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewFeedbackController : ControllerBase
    {
        private readonly IInterviewFeedbackService _interviewFeedbackService;
        //private readonly ILogger _logger;

        public InterviewFeedbackController(IInterviewFeedbackService interviewFeedbackService)
        {
            _interviewFeedbackService = interviewFeedbackService;
            //_logger = logger;
        }

        [HttpGet("GetAllInterviewFeedbacks")]
        public async Task<IActionResult> AllInterviews()
        {
            var interviewFeedbacks = await _interviewFeedbackService.GetAllInterviewFeedbacks();
            return Ok(interviewFeedbacks);
        }

        [HttpPost("AddNewInterviewFeedback")]
        public async Task<IActionResult> InsertInterviewFeedback(InterviewFeedbackRequestModel interviewFeedback)
        {
            try
            {
                await _interviewFeedbackService.AddInterviewFeedbackAsync(interviewFeedback);
                return Ok(interviewFeedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteInterviewFeedbackById/{id}")]
        public async Task<IActionResult> DeleteInterviewFeedbackById(int id)
        {
            try
            {
                await _interviewFeedbackService.DeleteInterviewFeedbackAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateInterviewFeedback")]
        public async Task<IActionResult> UpdateInterviewFeedbackInfo(InterviewFeedbackRequestModel interviewFeedback)
        {
            try
            {
                await _interviewFeedbackService.UpdateInterviewFeedbackAsync(interviewFeedback);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found interview feedback: " + ex);
            }
        }

        [HttpGet("GetInterviewFeedbackById/{id}")]
        public async Task<IActionResult> GetInterviewFeedbackById(int id)
        {
            var result = await _interviewFeedbackService.GetInterviewFeedbackByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Interview Feedback not Found\n");
        }
    }
}

