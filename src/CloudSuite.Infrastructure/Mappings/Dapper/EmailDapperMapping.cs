namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class EmailDapperMapping : DommelEntityMap<Email>
    {
        public EmailDapperMapping()
        {
            ToTable("Emails");
            Map(p => p.Id).IsKey();
            Map(p => p.Subject).ToColumn("Subject");
            Map(p => p.Body).ToColumn("Body");
            Map(p => p.Sender).ToColumn("Sender");
            Map(p => p.Recipient).ToColumn("Recipient");
            Map(p => p.SentDate).ToColumn("SentDate");
            Map(p => p.IsRead).ToColumn("IsRead");
            Map(p => p.SendAttempts).ToColumn("SendAttempts");
            Map(p => p.CodeErrorEmail).ToColumn("CodeErrorEmail");

            
        }
        
    }
}