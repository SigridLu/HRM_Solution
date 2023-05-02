using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Recruiting_ApplicationCore.Contract.Repository;
using Recruiting_ApplicationCore.Data;
using Recruiting_Infrastructure.Data;

namespace Recruiting_Infrastructure.Repository
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where,
            params Expression<Func<Candidate, object>>[] includes)
        {
            var query = _dbContext.Set<Candidate>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<Candidate> GetUserByEmail(string email)
        {
            return await _dbContext.Candidate.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}

