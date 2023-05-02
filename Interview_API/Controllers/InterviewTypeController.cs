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
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeService _interviewTypeService;
        //private readonly ILogger _logger;

        public InterviewTypeController(IInterviewTypeService interviewTypeService)
        {
            _interviewTypeService = interviewTypeService;
            //_logger = logger;
        }

        [HttpGet("GetAllInterviewTypes")]
        public async Task<IActionResult> AllInterviewTypes()
        {
            var types = await _interviewTypeService.GetAllInterviewTypes();
            return Ok(types);
        }

        [HttpPost("AddNewInterviewType")]
        public async Task<IActionResult> InsertInterviewType(InterviewTypeRequestModel type)
        {
            try
            {
                await _interviewTypeService.AddInterviewTypeAsync(type);
                return Ok(type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteInterviewTypeById/{id}")]
        public async Task<IActionResult> DeleteInterviewTypeById(int id)
        {
            try
            {
                await _interviewTypeService.DeleteInterviewTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateInterviewType")]
        public async Task<IActionResult> UpdateInterviewTypeInfo(InterviewTypeRequestModel type)
        {
            try
            {
                await _interviewTypeService.UpdateInterviewTypeAsync(type);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found type: " + ex);
            }
        }

        [HttpGet("GetInterviewTypeById/{id}")]
        public async Task<IActionResult> GetInterviewTypeById(int id)
        {
            var result = await _interviewTypeService.GetInterviewTypeByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Type not Found\n");
        }
    }
}

