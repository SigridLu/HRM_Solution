using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_ApplicationCore.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onboarding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleService _roleService;
        public EmployeeRoleController(IEmployeeRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAllEmployeeRoles")]
        public async Task<IActionResult> AllEmployeeRoles()
        {
            var roles = await _roleService.GetAllEmployeeRoles();
            return Ok(roles);
        }

        [HttpPost("AddNewEmployeeRole")]
        public async Task<IActionResult> InsertEmployeeRole(EmployeeRoleRequestModel role)
        {
            try
            {
                await _roleService.AddEmployeeRoleAsync(role);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteEmployeeRoleById/{id}")]
        public async Task<IActionResult> DeleteEmployeeRoleById(int id)
        {
            try
            {
                await _roleService.DeleteEmployeeRoleAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateEmployeeRole")]
        public async Task<IActionResult> UpdateEmployeeRoleInfo(EmployeeRoleRequestModel role)
        {
            try
            {
                await _roleService.UpdateEmployeeRoleAsync(role);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found role: " + ex);
            }
        }

        [HttpGet("GetEmployeeRoleById/{id}")]
        public async Task<IActionResult> GetEmployeeRoleById(int id)
        {
            var result = await _roleService.GetEmployeeRoleByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Role not Found\n");
        }
    }
}

