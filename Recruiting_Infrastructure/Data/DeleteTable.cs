using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruiting_Infrastructure.Data
{
    public partial class DeleteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            throw new NotImplementedException();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("dbo.Candidates");
            migrationBuilder.DropTable("dbo.JobRequirements");
            migrationBuilder.DropTable("dbo.Submissions");
            migrationBuilder.DropTable("dbo.SubmissionStatuses");
        }
    }
}

