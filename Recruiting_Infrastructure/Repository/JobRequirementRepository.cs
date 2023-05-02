using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Recruiting_ApplicationCore.Contract.Repository;
using Recruiting_ApplicationCore.Data;
using Recruiting_Infrastructure.Data;

namespace Recruiting_Infrastructure.Repository
{
    public class JobRequirementRepository : BaseRepository<JobRequirement>, IJobRequirementRepository
    {
        public JobRequirementRepository(RecruitingDbContext context) : base(context)
        {
        }

        /*public async Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter)
        {
            return await _dbContext.JobRequirement.Include("JobCategory").Where(filter).ToListAsync();
        }*/
    }
}

