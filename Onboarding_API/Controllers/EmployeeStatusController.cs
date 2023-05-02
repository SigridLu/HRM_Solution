using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_ApplicationCore.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onboarding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusService _statusService;
        public EmployeeStatusController(IEmployeeStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("GetAllEmployeeStatuses")]
        public async Task<IActionResult> AllEmployeeStatuses()
        {
            var statuses = await _statusService.GetAllEmployeeStatuss();
            return Ok(statuses);
        }

        [HttpPost("AddNewEmployeeStatuse")]
        public async Task<IActionResult> InsertEmployeeStatuse(EmployeeStatusRequestModel status)
        {
            try
            {
                await _statusService.AddEmployeeStatusAsync(status);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteEmployeeStatusById/{id}")]
        public async Task<IActionResult> DeleteEmployeeStatusById(int id)
        {
            try
            {
                await _statusService.DeleteEmployeeStatusAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateEmployeeStatus")]
        public async Task<IActionResult> UpdateEmployeeStatusInfo(EmployeeStatusRequestModel status)
        {
            try
            {
                await _statusService.UpdateEmployeeStatusAsync(status);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found status: " + ex);
            }
        }

        [HttpGet("GetEmployeeStatusById/{id}")]
        public async Task<IActionResult> GetEmployeeStatusById(int id)
        {
            var result = await _statusService.GetEmployeeStatusByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Status not Found\n");
        }
    }
}

