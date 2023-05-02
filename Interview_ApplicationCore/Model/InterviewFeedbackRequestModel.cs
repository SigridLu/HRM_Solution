using System;
namespace Interview_ApplicationCore.Model
{
    public class InterviewFeedbackRequestModel
    {
        public int InterviewFeedbackId { get; set; }
        public int Rating { get; set; }
        public string? comment { get; set; }
    }
}

