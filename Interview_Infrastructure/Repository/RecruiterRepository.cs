using System;
using Dapper;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Entity;
using Interview_Infrastructure.Data;

namespace Interview_Infrastructure.Repository
{
    public class RecruiterRepository : IBaseRepository<Recruiter>, IRecruiterRepository
    {
        private readonly InterviewDbContext _dbContext;

        public RecruiterRepository(InterviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Recruiter WHERE RecruiterId = @RecruiterId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { RecruiterId = id });
            }
        }

        public async Task<IEnumerable<Recruiter>> GetAllAsync()
        {
            var query = "SELECT * FROM Recruiter";
            using (var connection = _dbContext.CreateConnection())
            {
                var recruiters = await connection.QueryAsync<Recruiter>(query);
                return recruiters.ToList();
            }
        }

        public async Task<Recruiter> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Recruiter WHERE RecruiterId = @RecruiterId";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Recruiter>(query, new { RecruiterId = id });
            }
        }

        public async Task<int> InsertAsync(Recruiter entity)
        {
            var query = "INSERT INTO Recruiter VALUES(@RecruiterId, @FirstName, @LastName, @EmployeeId)";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(Recruiter entity)
        {
            var query = "UPDATE Recruiter SET RecruiterId = @Id, FirstName = @FirstName, LastName = @LastName, EmployeeId = @EmployeeId WHERE RecruiterId = @RecruiterId";

            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
}

