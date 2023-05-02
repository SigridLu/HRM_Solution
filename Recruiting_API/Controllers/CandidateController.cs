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
    [Authorize(Roles = "Admin,User")] // Only Admin and User(after login) are able to access Candidate API
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        //private readonly ILogger _logger;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
            //_logger = logger;
        }

        [HttpGet("GetAllCandidates")]
        public async Task<IActionResult> AllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            return Ok(candidates);
        }

        [HttpPost("AddNewCandidate")]
        public async Task<IActionResult> InsertCandidate(CandidateRequestModel candidate)
        {
            try
            {
                await _candidateService.AddCandidateAsync(candidate);
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteCandidateById/{id}")]
        public async Task<IActionResult> DeleteCandidateById(int id)
        {
            try
            {
                await _candidateService.DeleteCandidateAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateCandidate")]
        public async Task<IActionResult> UpdateCandidateInfo(CandidateRequestModel candidate)
        {
            try
            {
                await _candidateService.UpdateCandidateAsync(candidate);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found candidate: " + ex);
            }
        }

        [HttpGet("GetCandidateById/{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var result = await _candidateService.GetCandidateByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Candidate not Found\n");
        }
    }
}

