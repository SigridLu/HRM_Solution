using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_ApplicationCore.Model;

namespace Onboarding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> AllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost("AddNewEmployee")]
        public async Task<IActionResult> InsertEmployee(EmployeeRequestModel employee)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteEmployeeById/{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeInfo(EmployeeRequestModel employee)
        {
            try
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found employee: " + ex);
            }
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> AllEmployees(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Employee not Found\n");
        }
    }
}

