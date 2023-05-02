using System;
using System.Linq.Expressions;
using Recruiting_ApplicationCore.Data;

namespace Recruiting_ApplicationCore.Contract.Repository
{
    public interface ISubmissionRepository : IBaseRepository<Submission>
    {
        //public Task<Submission> GetSubmissionsByJobAndCandidateIdAsync(int jobReqId, int candidateId);
        public Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where,
            params Expression<Func<Submission, object>>[] includes);
    }
}

