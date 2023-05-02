using System;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Interview_Infrastructure.Data
{
    public class InterviewDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public InterviewDbContext(IConfiguration configuration)
        {
            //_configuration = configuration;
            //_connectionString = _configuration.GetConnectionString("HRM_Interview");
            _connectionString = Environment.GetEnvironmentVariable("InterviewDbContext");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}