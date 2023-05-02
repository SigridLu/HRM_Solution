using System;
using System.Linq.Expressions;
using Interview_ApplicationCore.Entity;

namespace Interview_ApplicationCore.Contract.Repository
{
    public interface IInterviewRepository : IBaseRepository<Interview>
    {
        /*Task<Interview> FirstOrDefaultWithIncludesAsync(Expression<Func<Interview, bool>> where,
          params Expression<Func<Interview, object>>[] includes);*/
    }
}

