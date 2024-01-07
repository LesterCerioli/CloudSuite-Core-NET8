namespace CloudSuite.Domain.Enums
{
    public enum CodeErrorEmail
    {
        None = 0,            // No error
        
        UnknownError = 1,    // Unknown or unspecified error
        
        SmtpError = 2,       // SMTP server error
        
        InvalidRecipient = 3, // Invalid recipient address
        
        NetworkError = 4,    // Network-related error
        
        AttachmentError = 5, // Error with email attachments
        
        TimeoutError = 6,   // Sending timeout error
        
        AuthenticationError = 7, // Authentication failure


        
    }
}