namespace JobTastic.Models
{
    public class ContactMail
    {
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public ContactMail(string toEmail, string fromEmail, string subject, string body)
        {
            ToEmail = toEmail;
            FromEmail = fromEmail;
            Subject = subject;
            Body = body;
        }
    }
}

