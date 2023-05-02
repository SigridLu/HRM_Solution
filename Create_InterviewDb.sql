Create Database HRM_Interview
Begin TRANSACTION

Create Table Recruiter(
    RecruiterId int Primary Key,
    FirstName nvarchar(128) Not NULL,
    LastName nvarchar(128) Not NULL,
    EmployeeId int
)

Create Table InterviewType(
    LookupCode int Primary Key,
    Description nvarchar(128)
)

Create Table Interviewer(
    InterviewerId int Primary Key,
    FirstName nvarchar(128) not null,
    LastName nvarchar(128) not null,
    EmployeeId int
)

Create Table InterviewFeedback(
    InterviewFeedbackId int Primary Key,
    Rating int not null,
    comment nvarchar
)

Create Table Interview(
    InterviewId int PRIMARY KEY,
    RecruiterId int FOREIGN KEY REFERENCES Recruiter(RecruiterId),
    SubmissionId int,
    InterviewTypeCode int FOREIGN Key REFERENCES InterviewType(LookupCode),
    InterviewRound int,
    ScheduledOn DATE,
    InterviewerId int FOREIGN Key REFERENCES Interviewer(InterviewerId),
    FeedbackId int FOREIGN Key REFERENCES InterviewFeedback(InterviewFeedbackId)
)
