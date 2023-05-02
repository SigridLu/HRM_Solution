using System;
using System.Linq.Expressions;
using Onboarding_ApplicationCore.Entity;

namespace Onboarding_ApplicationCore.Contract.Repository
{
    public interface IEmployeeRoleRepository : IBaseRepository<EmployeeRole>
    {
        Task<EmployeeRole> GetEmployeeRoleByRoleName(string RoleName);
    }
}