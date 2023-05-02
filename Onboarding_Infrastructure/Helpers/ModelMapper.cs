using System;
using Onboarding_ApplicationCore.Entity;
using Onboarding_ApplicationCore.Model;

namespace Onboarding_Infrastructure.Helpers
{
    public static class ModelMapper
    {
        public static EmployeeResponseModel ToEmployeeResponseModel(this Employee employee)
        {
            return new EmployeeResponseModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeCategoryCode = employee.EmployeeCategoryCode,
                EmployeeStatusCode = employee.EmployeeStatusCode,
                EmployeeRoleId = employee.EmployeeRoleId
            };
        }

        public static EmployeeCategoryResponseModel ToEmployeeCategoryResponseModel(this EmployeeCategory category)
        {
            return new EmployeeCategoryResponseModel
            {
                Id = category.Id,
                LookupCode = category.LookupCode,
                Description = category.Description
            };
        }

        public static EmployeeStatusResponseModel ToEmployeeStatusResponseModel(this EmployeeStatus status)
        {
            return new EmployeeStatusResponseModel
            {
                Id = status.Id,
                LookupCode = status.LookupCode,
                Description = status.Description,
                ABBR = status.ABBR
            };
        }

        public static EmployeeRoleResponseModel ToEmployeeRoleResponseModel(this EmployeeRole role)
        {
            return new EmployeeRoleResponseModel
            {
                Id = role.Id,
                LookupCode = role.LookupCode,
                Name = role.Name,
                ABBR = role.ABBR
            };
        }
    }
}

