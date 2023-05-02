using System;
namespace Recruiting_ApplicationCore.Model
{
    public class SubmissionStatusResponseModel
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }
        public string? Description { get; set; }
        public int SubmissionId { get; set; }
    }
}

