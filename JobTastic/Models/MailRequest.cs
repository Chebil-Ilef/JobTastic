namespace JobTastic.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailRequest(string toEmail, string subject, string body)
        {
            ToEmail = toEmail;
            Subject = subject;
            Body = body;
        }
    }
}
