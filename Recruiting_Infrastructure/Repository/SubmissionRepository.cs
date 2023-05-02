using System;
using Microsoft.EntityFrameworkCore;
using Recruiting_ApplicationCore.Data;
using Recruiting_Infrastructure.Data;
using System.Linq.Expressions;
using Recruiting_ApplicationCore.Contract.Repository;

namespace Recruiting_Infrastructure.Repository
{
    public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where,
            params Expression<Func<Submission, object>>[] includes)
        {
            var query = _dbContext.Set<Submission>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }
    }
}

