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
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _recruiterService;
        //private readonly ILogger _logger;

        public RecruiterController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
            //_logger = logger;
        }

        [HttpGet("GetAllRecruiters")]
        public async Task<IActionResult> AllRecruiters()
        {
            var recruiters = await _recruiterService.GetAllRecruiters();
            return Ok(recruiters);
        }

        [HttpPost("AddNewRecruiter")]
        public async Task<IActionResult> InsertRecruiter(RecruiterRequestModel recruiter)
        {
            try
            {
                await _recruiterService.AddRecruiterAsync(recruiter);
                return Ok(recruiter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteRecruiterById/{id}")]
        public async Task<IActionResult> DeleteRecruiterById(int id)
        {
            try
            {
                await _recruiterService.DeleteRecruiterAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateInterview")]
        public async Task<IActionResult> UpdateRecruiterInfo(RecruiterRequestModel recruiter)
        {
            try
            {
                await _recruiterService.UpdateRecruiterAsync(recruiter);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found recruiter: " + ex);
            }
        }

        [HttpGet("GetRecruiterById/{id}")]
        public async Task<IActionResult> GetRecruiterById(int id)
        {
            var result = await _recruiterService.GetRecruiterByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Recruiter not Found\n");
        }
    }
}

