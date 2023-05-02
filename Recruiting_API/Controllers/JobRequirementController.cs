using System;
using Microsoft.AspNetCore.Mvc;
using Recruiting_ApplicationCore.Contract.Service;
using Recruiting_ApplicationCore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Recruiting_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementService _jobRequirementService;

        public JobRequirementController(IJobRequirementService jobRequirementService)
        {
            _jobRequirementService = jobRequirementService;
        }

        [HttpGet("GetAllJobRequirements")]
        public async Task<IActionResult> AllJobRequirements()
        {
            var jRs = await _jobRequirementService.GetAllJobRequirements();
            return Ok(jRs);
        }

        // Add Authorization layer to create a job requirement
        [Authorize]
        [HttpPost("AddNewJobRequirement")]
        public async Task<IActionResult> InsertJobRequirement(JobRequirementRequestModel jobRequirement)
        {
            try
            {
                await _jobRequirementService.AddJobRequirementAsync(jobRequirement);
                return Ok(jobRequirement);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteJobRequirementById/{id}")]
        public async Task<IActionResult> DeleteJobRequirementById(int id)
        {
            try
            {
                await _jobRequirementService.DeleteJobRequirementAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateJobRequirement")]
        public async Task<IActionResult> UpdateJobRequirementInfo(JobRequirementRequestModel jobRequirement)
        {
            try
            {
                await _jobRequirementService.UpdateJobRequirementAsync(jobRequirement);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Cannot found job requirement: " + ex);
            }
        }

        [HttpGet("GetJobRequirementById/{id}")]
        public async Task<IActionResult> GetJobRequirementById(int id)
        {
            var result = await _jobRequirementService.GetJobRequirementByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Job Requirement Not Found\n");
        }
    }
}

