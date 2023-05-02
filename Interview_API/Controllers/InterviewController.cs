using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interview_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        //private readonly ILogger _logger;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
            //_logger = logger;
        }

        [HttpGet("GetAllInterviews")]
        public async Task<IActionResult> AllInterviews()
        {
            var interviews = await _interviewService.GetAllInterviews();
            return Ok(interviews);
        }

        [HttpPost("AddNewInterview")]
        public async Task<IActionResult> InsertInterview(InterviewRequestModel interview)
        {
            // Put in candidate Id to register candidate meeting
            try
            {
                await _interviewService.AddInterviewAsync(interview);
                return Ok(interview);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteInterviewById/{id}")]
        public async Task<IActionResult> DeleteInterviewById(int id)
        {
            try
            {
                await _interviewService.DeleteInterviewAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateInterview")]
        public async Task<IActionResult> UpdateInterviewInfo(InterviewRequestModel interview)
        {
            try
            {
                await _interviewService.UpdateInterviewAsync(interview);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found interview: " + ex);
            }
        }

        [HttpGet("GetInterviewById/{id}")]
        public async Task<IActionResult> GetInterviewById(int id)
        {
            var result = await _interviewService.GetInterviewByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Interview not Found\n");
        }


        // Example to communicate with other assembly
        [HttpGet("GetCandidates")]
        public async Task<IActionResult> GetCandicates()
        {
            string str = "http://host.docker.internal:40123/api/Candidate/GetAllCandidates";
            HttpClient client = new HttpClient();
            var candidateResponse = await client.GetFromJsonAsync<IEnumerable<CandidateResponseModel>>(str);
            if (candidateResponse != null)
            {
                return Ok(candidateResponse);
            }
            return BadRequest(str);
        }

        [HttpGet("GetCandidateById")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            string str = $"http://host.docker.internal:40123/api/Candidate/GetCandidateById/{id}";
            var client = new HttpClient();
            var getCandidateById = await client.GetFromJsonAsync<CandidateResponseModel>(str);

            if (getCandidateById == null)
                throw new Exception("Candidate does not exist");
            else
            {
                return Ok(getCandidateById);
            }
        }

        /*[HttpPost("AddNewInterview")]
        public async Task<IActionResult> InsertInterview(InterviewRequestModel interview)
        {
            // Put in Add new candidate info to register candidate meeting
            try
            {
                var candidateId = interview.CandidateId;
                string str = $"http://host.docker.internal:40123/api/Candidate/GetCandidateById/{candidateId}";
                var client = new HttpClient();
                var getCandidateById = await client.GetFromJsonAsync<CandidateResponseModel>(str);

                await _interviewService.AddInterviewAsync(interview);
                return Ok(interview);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }*/
    }
}

