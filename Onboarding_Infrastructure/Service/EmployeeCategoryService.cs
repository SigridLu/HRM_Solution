using System;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_ApplicationCore.Entity;
using Onboarding_ApplicationCore.Model;
using Onboarding_Infrastructure.Helpers;

namespace Onboarding_Infrastructure.Service
{
    public class EmployeeCategoryService : IEmployeeCategoryService
    {
        IEmployeeCategoryRepository categoryRepo;
        IEmployeeRepository employeeRepo;
        public EmployeeCategoryService(IEmployeeCategoryRepository _categoryRepo, IEmployeeRepository _employeeRepo)
        {
            categoryRepo = _categoryRepo;
            employeeRepo = _employeeRepo;
        }

        public async Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            var existingCategory = await employeeRepo.FirstOrDefaultWithIncludesAsync(e => e.EmployeeCategoryCode == model.LookupCode);
            if (existingCategory != null)
                throw new Exception("Status is already exist");
            else
            {
                EmployeeCategory category = new EmployeeCategory();
                if (model != null)
                {
                    category.Id = model.Id;
                    category.LookupCode = model.LookupCode;
                    category.Description = model.Description;
                    category.Employees = new List<Employee>();
                }
                return await categoryRepo.InsertAsync(category);
            }
        }

        public async Task<int> DeleteEmployeeCategoryAsync(int id)
        {
            return await categoryRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorys()
        {
            var categories = await categoryRepo.GetAllAsync();
            var response = categories.Select(x => x.ToEmployeeCategoryResponseModel());
            return response;
        }

        public async Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id)
        {
            var category = await categoryRepo.GetByIdAsync(id);
            var response = category.ToEmployeeCategoryResponseModel();
            return response;
        }

        public async Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            var existingStatus = await employeeRepo.FirstOrDefaultWithIncludesAsync(e => e.EmployeeCategoryCode == model.LookupCode);
            if (existingStatus == null)
                throw new Exception("Category doesn't exist");
            else
            {
                EmployeeCategory category = new EmployeeCategory();
                if (model != null)
                {
                    category.Id = model.Id;
                    category.LookupCode = model.LookupCode;
                    category.Description = model.Description;
                }
                return await categoryRepo.UpdateAsync(category);
            }
        }
    }
}

