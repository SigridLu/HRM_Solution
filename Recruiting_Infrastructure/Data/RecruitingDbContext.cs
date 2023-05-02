using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recruiting_ApplicationCore.Data;

namespace Recruiting_Infrastructure.Data
{
    public class RecruitingDbContext : DbContext
    {
        //base is for calling the second constructor of DbContext that takes DbContextOptions as argument
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Submission> Submission { get; set; }
        public DbSet<SubmissionStatus> SubmissionStatuse { get; set; }
        public DbSet<JobRequirement> JobRequirement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<Candidate>(ConfigureCandidate);
            modelBuilder.Entity<Submission>(ConfigureSubmission);
            modelBuilder.Entity<SubmissionStatus>(ConfigureSubmissionStatus);
            modelBuilder.Entity<JobRequirement>(ConfigureJobRequirement);
        }

        private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidate");
            builder.HasKey(c => c.Id);
        }

        public void ConfigureSubmission(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("Submission");
            builder.HasKey(s => s.Id);
            builder.HasAlternateKey(s => new { s.JobRequirementId, s.CandidateId });
            builder.HasOne(s => s.Candidate).WithMany(c => c.Submissions).HasForeignKey(s => s.CandidateId);
            builder.HasOne(s => s.JobRequirement).WithMany(j => j.Submissions).HasForeignKey(s => s.JobRequirementId);
            //builder.HasMany<SubmissionStatus>(ss => ss.SubmissionStatuses).WithOne(s => s.Submission).HasForeignKey(s => s.LookupCode);
        }

        public void ConfigureSubmissionStatus(EntityTypeBuilder<SubmissionStatus> builder)
        {
            builder.ToTable("SubmissionStatuse");
            builder.HasKey(ss => ss.LookupCode);
        }

        public void ConfigureJobRequirement(EntityTypeBuilder<JobRequirement> builder)
        {
            builder.ToTable("JobRequirement");
            builder.HasKey(j => j.Id);
        }
    }
}

