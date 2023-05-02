using System;
using System.Linq.Expressions;
using Dapper;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Entity;
using Interview_Infrastructure.Data;

namespace Interview_Infrastructure.Repository
{
    public class InterviewRepository : IBaseRepository<Interview>, IInterviewRepository
    {
        private readonly InterviewDbContext _dbContext;

        public InterviewRepository(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Interview WHERE InterviewId = @InterviewId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { InterviewId = id });
            }
        }

        public async Task<IEnumerable<Interview>> GetAllAsync()
        {
            var query = "SELECT * FROM Interview";
            using (var connection = _dbContext.CreateConnection())
            {
                var interviews = await connection.QueryAsync<Interview>(query);
                return interviews.ToList();
            }
        }

        public async Task<Interview> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Interview WHERE InterviewId = @InterviewId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Interview>(query, new { InterviewId = id });
            }
        }

        public async Task<int> InsertAsync(Interview entity)
        {
            var query = "INSERT INTO Interview VALUES(@InterviewId, @RecruiterId, @SubmissionId, @InterviewTypeCode, @InterviewRound, @ScheduledOn, @InterviewerId, @FeedbackId, @CandidateId)";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(Interview entity)
        {
            var query = "UPDATE Interview SET InterviewId = @InterviewId, RecruiterId = @RecruiterId, SubmissionId = @SubmissionId, InterviewTypeCode = @InterviewTypeCode, InterviewRound = @InterviewRound, ScheduledOn = @ScheduledOn, InterviewerId = @InterviewerId, FeedbackId = @FeedbackId, @CandidateId = CandidateId";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
}

