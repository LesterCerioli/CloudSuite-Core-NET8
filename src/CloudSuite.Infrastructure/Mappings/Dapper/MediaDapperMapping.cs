namespace CloudSuite.Infrastructure.Mappings.Dapper
{
    public class MediaDapperMapping : DommelEntityMap<Media>
    {
        public MediaDapperMapping()
        {
            ToTable("Medias");
            Map(p => p.Id).IsKey();
            Map(p => p.Caption).ToColumn("Caption");
            Map(p => p.FileSize).ToColumn("FileSize");
            Map(p => p.FileName).ToColumn("FileName");
            Map(p => p.MediaType).ToColumn("MediaType");

            
        }
        
    }
}