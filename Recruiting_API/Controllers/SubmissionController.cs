using System;
using Microsoft.AspNetCore.Mvc;
using Recruiting_ApplicationCore.Contract.Service;
using Recruiting_ApplicationCore.Model;

namespace Recruiting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet("GetAllSubmissions")]
        public async Task<IActionResult> AllSubmissions()
        {
            var submissions = await _submissionService.GetAllSubmissions();
            return Ok(submissions);
        }

        [HttpPost("AddNewSubmission")]
        public async Task<IActionResult> InsertSubmission(SubmissionRequestModel submission)
        {
            try
            {
                await _submissionService.AddSubmissionAsync(submission);
                return Ok(submission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteSubmissionById/{id}")]
        public async Task<IActionResult> DeleteSubmissionById(int id)
        {
            try
            {
                await _submissionService.DeleteSubmissionAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateSubmission")]
        public async Task<IActionResult> UpdateSubmissionInfo(SubmissionRequestModel submission)
        {
            try
            {
                await _submissionService.UpdateSubmissionAsync(submission);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found submission: " + ex);
            }
        }

        [HttpGet("GetSubmissionById/{id}")]
        public async Task<IActionResult> GetSubmissionById(int id)
        {
            var result = await _submissionService.GetSubmissionByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Submission Not Found\n");
        }
    }
}

