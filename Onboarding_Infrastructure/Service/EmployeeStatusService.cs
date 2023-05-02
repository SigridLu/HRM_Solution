using System;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_ApplicationCore.Entity;
using Onboarding_ApplicationCore.Model;
using Onboarding_Infrastructure.Helpers;

namespace Onboarding_Infrastructure.Service
{
    public class EmployeeStatusService : IEmployeeStatusService
    {
        IEmployeeStatusRepository statusRepo;
        IEmployeeRepository employeeRepo;

        public EmployeeStatusService(IEmployeeStatusRepository _statusRepo, IEmployeeRepository _employeeRepo)
        {
            statusRepo = _statusRepo;
            employeeRepo = _employeeRepo;
        }

        public async Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            var existingStatus = await employeeRepo.FirstOrDefaultWithIncludesAsync(e => e.EmployeeStatusCode == model.LookupCode);
            if (existingStatus != null)
                throw new Exception("Status is already exist");
            else
            {
                EmployeeStatus status = new EmployeeStatus();
                if (model != null)
                {
                    status.Id = model.Id;
                    status.LookupCode = model.LookupCode;
                    status.Description = model.Description;
                    status.ABBR = model.ABBR;
                    status.Employees = new List<Employee>();
                }
                return await statusRepo.InsertAsync(status);
            }
        }

        public async Task<int> DeleteEmployeeStatusAsync(int id)
        {
            return await statusRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatuss()
        {
            var statuses = await statusRepo.GetAllAsync();
            var response = statuses.Select(x => x.ToEmployeeStatusResponseModel());
            return response;
        }

        public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id)
        {
            var status = await statusRepo.GetByIdAsync(id);
            var response = status.ToEmployeeStatusResponseModel();
            return response;
        }

        public async Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            var existingStatus = await employeeRepo.FirstOrDefaultWithIncludesAsync(e => e.EmployeeStatusCode == model.LookupCode);
            if (existingStatus == null)
                throw new Exception("Status doesn't exist");
            else
            {
                EmployeeStatus status = new EmployeeStatus();
                if (model != null)
                {
                    status.Id = model.Id;
                    status.LookupCode = model.LookupCode;
                    status.Description = model.Description;
                    status.ABBR = model.ABBR;
                }
                return await statusRepo.UpdateAsync(status);
            }
        }
    }
}

