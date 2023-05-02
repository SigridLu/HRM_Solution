using System;
using Onboarding_ApplicationCore.Model;

namespace Onboarding_ApplicationCore.Contract.Service
{
    public interface IEmployeeRoleService
    {
        Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> DeleteEmployeeRoleAsync(int id);
        Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoles();
        Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id);
    }
}

