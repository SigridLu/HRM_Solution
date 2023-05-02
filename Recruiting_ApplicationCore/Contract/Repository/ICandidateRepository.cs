using System;
using System.Linq.Expressions;
using Recruiting_ApplicationCore.Data;

namespace Recruiting_ApplicationCore.Contract.Repository
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<Candidate> GetUserByEmail(string email);
        Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where,
          params Expression<Func<Candidate, object>>[] includes);
    }
}

