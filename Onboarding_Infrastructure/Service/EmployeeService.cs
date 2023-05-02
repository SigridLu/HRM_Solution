using System;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_ApplicationCore.Entity;
using Onboarding_ApplicationCore.Model;
using Onboarding_Infrastructure.Helpers;

namespace Onboarding_Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepo;
        public EmployeeService(IEmployeeRepository _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        public async Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee();
            if (model != null)
            {
                employee.Id = model.Id;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;
                employee.SSN = model.SSN;
                employee.HireDate = model.HireDate;
                employee.EndDate = model.EndDate;
                employee.Address = model.Address;
                employee.Email = model.Email;
                employee.EmployeeCategoryCode = model.EmployeeCategoryCode;
                employee.EmployeeStatusCode = model.EmployeeStatusCode;
                employee.EmployeeRoleId = model.EmployeeRoleId;
            }
            return await employeeRepo.InsertAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await employeeRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployees()
        {
            var employees = await employeeRepo.GetAllAsync();
            var response = employees.Select(x => x.ToEmployeeResponseModel());
            return response;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await employeeRepo.GetByIdAsync(id);
            var response = employee.ToEmployeeResponseModel();
            return response;
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            var existingEmployee = await employeeRepo.GetByIdAsync(model.Id);
            if (existingEmployee == null)
                throw new Exception("Employee does not exist");

            Employee employee = new Employee();

            if (model != null)
            {
                employee.Id = model.Id;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;
                employee.SSN = model.SSN;
                employee.HireDate = model.HireDate;
                employee.EndDate = model.EndDate;
                employee.Address = model.Address;
                employee.Email = model.Email;
                employee.EmployeeCategoryCode = model.EmployeeCategoryCode;
                employee.EmployeeStatusCode = model.EmployeeStatusCode;
                employee.EmployeeRoleId = model.EmployeeRoleId;
                return await employeeRepo.UpdateAsync(employee);
            }
            else
                return -1; // unsuccessful update
        }
    }
}

