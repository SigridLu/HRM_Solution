using System;
using Dapper;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Entity;
using Interview_Infrastructure.Data;

namespace Interview_Infrastructure.Repository
{
    public class InterviewTypeRepository : IBaseRepository<InterviewType>, IInterviewTypeRepository
    {
        private readonly InterviewDbContext _dbContext;

        public InterviewTypeRepository(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM InterviewType WHERE LookupCode = @LookupCode";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { LookupCode = id });
            }
        }

        public async Task<IEnumerable<InterviewType>> GetAllAsync()
        {
            var query = "SELECT * FROM InterviewType";
            using (var connection = _dbContext.CreateConnection())
            {
                var interviewTypes = await connection.QueryAsync<InterviewType>(query);
                return interviewTypes.ToList();
            }
        }

        public async Task<InterviewType> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM InterviewType WHERE LookupCode = @LookupCode";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<InterviewType>(query, new { LookupCode = id });
            }
        }

        public async Task<int> InsertAsync(InterviewType entity)
        {
            var query = "INSERT INTO InterviewType VALUES(@LookupCode, @Description)";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(InterviewType entity)
        {
            var query = "UPDATE InterviewType SET LookupCode = @LookupCode, Description = @Description WHERE LookupCode = @LookupCode";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
}

