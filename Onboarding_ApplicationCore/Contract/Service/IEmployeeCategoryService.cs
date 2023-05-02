using System;
using Onboarding_ApplicationCore.Model;

namespace Onboarding_ApplicationCore.Contract.Service
{
    public interface IEmployeeCategoryService
    {
        Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> DeleteEmployeeCategoryAsync(int id);
        Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorys();
        Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id);
    }
}

