using System;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_ApplicationCore.Entity;
using Onboarding_ApplicationCore.Model;
using Onboarding_Infrastructure.Helpers;

namespace Onboarding_Infrastructure.Service
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        IEmployeeRoleRepository roleRepo;
        IEmployeeRepository employeeRepo;
        public EmployeeRoleService(IEmployeeRoleRepository _roleRepo, IEmployeeRepository _employeeRepo)
        {
            roleRepo = _roleRepo;
            employeeRepo = _employeeRepo;
        }

        public async Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            var existingStatus = await employeeRepo.FirstOrDefaultWithIncludesAsync(e => e.EmployeeRoleId == model.LookupCode);
            if (existingStatus != null)
                throw new Exception("Role is already exist");
            else
            {
                EmployeeRole role = new EmployeeRole();
                if (model != null)
                {
                    role.Id = model.Id;
                    role.LookupCode = model.LookupCode;
                    role.Name = model.Name;
                    role.ABBR = model.ABBR;
                    role.Employees = new List<Employee>();
                }
                return await roleRepo.InsertAsync(role);
            }
        }

        public async Task<int> DeleteEmployeeRoleAsync(int id)
        {
            return await roleRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoles()
        {
            var roles = await roleRepo.GetAllAsync();
            var response = roles.Select(x => x.ToEmployeeRoleResponseModel());
            return response;
        }

        public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id)
        {
            var role = await roleRepo.GetByIdAsync(id);
            var response = role.ToEmployeeRoleResponseModel();
            return response;
        }

        public async Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            var existingStatus = await employeeRepo.FirstOrDefaultWithIncludesAsync(e => e.EmployeeRoleId == model.LookupCode);
            if (existingStatus == null)
                throw new Exception("Role doesn't exist");
            else
            {
                EmployeeRole role = new EmployeeRole();
                if (model != null)
                {
                    role.Id = model.Id;
                    role.LookupCode = model.LookupCode;
                    role.Name = model.Name;
                    role.ABBR = model.ABBR;
                }
                return await roleRepo.UpdateAsync(role);
            }
        }
    }
}

