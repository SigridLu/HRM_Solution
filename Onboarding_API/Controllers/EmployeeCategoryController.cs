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
    public class EmployeeCategoryController : ControllerBase
    {
        private readonly IEmployeeCategoryService _categoryService;
        public EmployeeCategoryController(IEmployeeCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllEmployeeCategories")]
        public async Task<IActionResult> AllEmployeeCategories()
        {
            var categories = await _categoryService.GetAllEmployeeCategorys();
            return Ok(categories);
        }

        [HttpPost("AddNewEmployeeCategory")]
        public async Task<IActionResult> InsertEmployeeCategory(EmployeeCategoryRequestModel category)
        {
            try
            {
                await _categoryService.AddEmployeeCategoryAsync(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteEmployeeCategoryById/{id}")]
        public async Task<IActionResult> DeleteEmployeeCategoryById(int id)
        {
            try
            {
                await _categoryService.DeleteEmployeeCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("UpdateEmployeeCategory")]
        public async Task<IActionResult> UpdateEmployeeCategoryInfo(EmployeeCategoryRequestModel category)
        {
            try
            {
                await _categoryService.UpdateEmployeeCategoryAsync(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Cannot found category: " + ex);
            }
        }

        [HttpGet("GetEmployeeCategoryById/{id}")]
        public async Task<IActionResult> GetEmployeeCategoryById(int id)
        {
            var result = await _categoryService.GetEmployeeCategoryByIdAsync(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Category not Found\n");
        }
    }
}

