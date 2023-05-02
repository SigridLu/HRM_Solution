using System;
using Onboarding_ApplicationCore.Model;

namespace Onboarding_ApplicationCore.Contract.Service
{
    public interface IEmployeeService
    {
        Task<int> AddEmployeeAsync(EmployeeRequestModel model);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel model);
        Task<int> DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployees();
        Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
    }
}

