using System;
namespace Interview_ApplicationCore.Entity
{
    public class InterviewFeedback
    {
        public int InterviewFeedbackId { get; set; }
        public int Rating { get; set; }
        public string? comment { get; set; }
    }
}

