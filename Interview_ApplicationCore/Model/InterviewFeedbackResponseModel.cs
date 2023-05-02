using System;
namespace Interview_ApplicationCore.Model
{
    public class InterviewFeedbackResponseModel
    {
        public int InterviewFeedbackId { get; set; }
        public int Rating { get; set; }
        public string? comment { get; set; }
    }
}

