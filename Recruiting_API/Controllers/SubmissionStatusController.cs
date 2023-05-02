using System;
using Microsoft.AspNetCore.Mvc;
using Recruiting_ApplicationCore.Contract.Service;
using Recruiting_ApplicationCore.Model;

namespace Recruiting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionStatusController : ControllerBase
    {
        private readonly ISubmissionStatusService _submissionStatusService;

        public SubmissionStatusController(ISubmissionStatusService submissionStatusService)
        {
            _submissionStatusService = submissionStatusService;
        }

        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> AllStatus()
        {
            var statuses = await _submissionStatusService.GetAllStatus();
            return Ok(statuses);
        }

        [HttpPost("AddNewStatus")]
        public async Task<IActionResult> InsertStatus(SubmissionStatusRequestModel submissionStatus)
        {
            try
            {
                await _submissionStatusService.AddStatusAsync(submissionStatus);
                return Ok(submissionStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteStatusById/{id}")]
        public async Task<IActionResult> DeleteStatusById(int id)
        {
            try
            {
                await _submissionStatusService.DeleteStatusAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatusInfo(SubmissionStatusRequestModel submissionStatus)
        {
            try
            {
                await _submissionStatusService.UpdateStatusAsync(submissionStatus);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found submission status: " + ex);
            }
        }

        [HttpGet("GetStatusById/{id}")]
        public async Task<IActionResult> GetStatusById(int id)
        {
            var result = await _submissionStatusService.GetStatusByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Submission status Not Found\n");
        }
    }
}

