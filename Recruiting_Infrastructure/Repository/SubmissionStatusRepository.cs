using System;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Recruiting_ApplicationCore.Contract.Repository;
using Recruiting_ApplicationCore.Data;
using Recruiting_Infrastructure.Data;

namespace Recruiting_Infrastructure.Repository
{
    public class SubmissionStatusRepository : BaseRepository<SubmissionStatus>, ISubmissionStatusRepository
    {
        public SubmissionStatusRepository(RecruitingDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<SubmissionStatus>> GetStatusByState(string state)
        {
            var statuses = await _dbContext.SubmissionStatuse.Where(s => s.LookupCode == state).Include(s => s.Submission).ToListAsync();
            return statuses;
        }
    }
}

