using System;
using Dapper;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Entity;
using Interview_Infrastructure.Data;

namespace Interview_Infrastructure.Repository
{
    public class InterviewFeedbackRepository : IBaseRepository<InterviewFeedback>, IInterviewFeedbackRepository
    {
        private readonly InterviewDbContext _dbContext;

        public InterviewFeedbackRepository(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM InterviewFeedback WHERE InterviewFeedbackId = @InterviewFeedbackId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { InterviewFeedbackId = id });
            }
        }

        public async Task<IEnumerable<InterviewFeedback>> GetAllAsync()
        {
            var query = "SELECT * FROM InterviewFeedback";
            using (var connection = _dbContext.CreateConnection())
            {
                var interviewFeedbacks = await connection.QueryAsync<InterviewFeedback>(query);
                return interviewFeedbacks.ToList();
            }
        }

        public async Task<InterviewFeedback> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM InterviewFeedback WHERE InterviewFeedbackId = @InterviewFeedbackId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<InterviewFeedback>(query, new { InterviewFeedbackId = id });
            }
        }

        public async Task<int> InsertAsync(InterviewFeedback entity)
        {
            var query = "INSERT INTO InterviewFeedback VALUES(@InterviewFeedbackId, @Rating, @Comment)";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(InterviewFeedback entity)
        {
            var query = "UPDATE InterviewFeedback SET InterviewFeedbackId = @InterviewFeedbackId, Rating = @Rating, Comment = @Comment WHERE InterviewFeedbackId = @InterviewFeedbackId";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
}

