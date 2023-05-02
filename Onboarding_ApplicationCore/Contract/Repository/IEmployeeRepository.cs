using System;
using Onboarding_ApplicationCore.Entity;
using System.Linq.Expressions;

namespace Onboarding_ApplicationCore.Contract.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public Task<Employee> FirstOrDefaultWithIncludesAsync(Expression<Func<Employee, bool>> where,
            params Expression<Func<Employee, object>>[] includes);
    }
}

