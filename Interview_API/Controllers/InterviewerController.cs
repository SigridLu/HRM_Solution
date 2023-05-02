using System;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;
using Interview_Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Interview_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerService _interviewerService;
        //private readonly ILogger _logger;

        public InterviewerController(IInterviewerService interviewerService)
        {
            _interviewerService = interviewerService;
            //_logger = logger;
        }

        [HttpGet("GetAllInterviewers")]
        public async Task<IActionResult> AllInterviewers()
        {
            var interviewers = await _interviewerService.GetAllInterviewers();
            return Ok(interviewers);
        }

        [HttpPost("AddNewInterviewer")]
        public async Task<IActionResult> InsertInterviewer(InterviewerRequestModel interviewer)
        {
            try
            {
                await _interviewerService.AddInterviewerAsync(interviewer);
                return Ok(interviewer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteInterviewerById/{id}")]
        public async Task<IActionResult> DeleteInterviewerById(int id)
        {
            try
            {
                await _interviewerService.DeleteInterviewerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateInterviewer")]
        public async Task<IActionResult> UpdateInterviewerInfo(InterviewerRequestModel interviewer)
        {
            try
            {
                await _interviewerService.UpdateInterviewerAsync(interviewer);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found interviewer: " + ex);
            }
        }

        [HttpGet("GetInterviewerById/{id}")]
        public async Task<IActionResult> GetInterviewerById(int id)
        {
            var result = await _interviewerService.GetInterviewerByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Interviewer not Found\n");
        }
    }
}

