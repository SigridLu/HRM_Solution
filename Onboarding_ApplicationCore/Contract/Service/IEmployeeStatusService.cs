using System;
using Onboarding_ApplicationCore.Model;

namespace Onboarding_ApplicationCore.Contract.Service
{
    public interface IEmployeeStatusService
    {
        Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> DeleteEmployeeStatusAsync(int id);
        Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatuss();
        Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id);
    }
}

