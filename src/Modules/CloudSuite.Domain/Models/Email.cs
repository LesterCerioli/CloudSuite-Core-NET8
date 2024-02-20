using CloudSuite.Domain.Enums;
using NetDevPack.Domain;

namespace CloudSuite.Domain.Models
{
    public class Email : Entity, IAggregateRoot
    {
        public Email(string? subject, string? body, string? sender, string? recipient, DateTimeOffset? sentDate, bool? isRead, int sendAttempts, CodeErrorEmail codeErrorEmail)
        {
            Subject = subject;
            Body = body;
            Sender = sender;
            Recipient = recipient;
            SentDate = sentDate;
            IsRead = isRead;
            SendAttempts = sendAttempts;
            CodeErrorEmail = codeErrorEmail;
        }

        public Email(){ }
        
        public string? Subject { get; private set; } // Email subject
        
        public string? Body { get; private set; } // Email body content
        
        public string? Sender { get; private set; } // Email sender's address
        
        public string? Recipient { get; private set; } // Email recipient's address
        
        public DateTimeOffset? SentDate { get; private set; } // Date and time when the email was sent
        
        public bool? IsRead { get; private set; } // Indicates whether the email has been read

        public int? SendAttempts { get; private set; } // Number of send attempts

        public CodeErrorEmail CodeErrorEmail { get; private set; }

        public Guid CodeErrorEmailId { get; private set; } // Adicionei esta propriedade para armazenar a chave estrangeira
    }
}