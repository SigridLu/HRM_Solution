        using System;
using System.Data;
using Dapper;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Entity;
using Interview_Infrastructure.Data;

namespace Interview_Infrastructure.Repository
{
    public class InterviewerRepository : IBaseRepository<Interviewer>, IInterviewerRepository
    {
        private readonly InterviewDbContext _dbContext;

        public InterviewerRepository(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Interviewer WHERE InterviewerId = @InterviewerId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { InterviewerId = id });
            }
        }

        public async Task<IEnumerable<Interviewer>> GetAllAsync()
        {
            var query = "SELECT * FROM Interviewer";
            using (var connection = _dbContext.CreateConnection())
            {
                var interviewers = await connection.QueryAsync<Interviewer>(query);
                return interviewers.ToList();
            }
        }

        public async Task<Interviewer> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Interviewer WHERE InterviewerId = @InterviewerId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Interviewer>(query, new { InterviewerId = id });
            }
        }

        public async Task<int> InsertAsync(Interviewer entity)
        {
            var query = "INSERT INTO Interviewer VALUES(@InterviewerId, @FirstName, @LastName, @EmployeeId)";

            /*var parameters = new DynamicParameters();
            parameters.Add("InterviewerId", entity.InterviewerId, DbType.Int32);
            parameters.Add("FirstName", entity.FirstName, DbType.String);
            parameters.Add("LastName", entity.LastName, DbType.String);
            parameters.Add("EmployeeId", entity.EmployeeId, DbType.Int32);*/

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(Interviewer entity)
        {
            var query = "UPDATE Interviewer SET InterviewerId = @InterviewerId, FirstName = @FirstName, LastName = @LastName, EmployeeId = @EmployeeId WHERE InterviewerId = @InterviewerId";

            /*var parameters = new DynamicParameters();
            parameters.Add("InterviewerId", entity.InterviewerId, DbType.Int32);
            parameters.Add("FirstName", entity.FirstName, DbType.String);
            parameters.Add("LastName", entity.LastName, DbType.String);
            parameters.Add("EmployeeId", entity.EmployeeId, DbType.Int32);*/

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
}

