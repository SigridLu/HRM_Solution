﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recruiting_Infrastructure.Data;

#nullable disable

namespace Recruiting_Infrastructure.Migrations
{
    [DbContext(typeof(RecruitingDbContext))]
    [Migration("20230424015601_InitialCreate_0423")]
    partial class InitialCreate_0423
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidate", (string)null);
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.JobRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClosedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HiringManagerId")
                        .HasColumnType("int");

                    b.Property<string>("HiringManagerName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfPositions")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("JobRequirement", (string)null);
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConfirmedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobRequirementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RejectedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionStatusCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmittedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasAlternateKey("JobRequirementId", "CandidateId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Submission", (string)null);
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.SubmissionStatus", b =>
                {
                    b.Property<string>("LookupCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.HasKey("LookupCode");

                    b.HasIndex("SubmissionId");

                    b.ToTable("SubmissionStatuse", (string)null);
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.Submission", b =>
                {
                    b.HasOne("Recruiting_ApplicationCore.Data.Candidate", "Candidate")
                        .WithMany("Submissions")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recruiting_ApplicationCore.Data.JobRequirement", "JobRequirement")
                        .WithMany("Submissions")
                        .HasForeignKey("JobRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("JobRequirement");
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.SubmissionStatus", b =>
                {
                    b.HasOne("Recruiting_ApplicationCore.Data.Submission", "Submission")
                        .WithMany("SubmissionStatuses")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.Candidate", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.JobRequirement", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Recruiting_ApplicationCore.Data.Submission", b =>
                {
                    b.Navigation("SubmissionStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
