namespace rebar.Models
{
    public class DatabaseSettings
    {
        public string? DatabaseName { get; set; } 
        public string? ConnectionString { get; set; }
        public string? AccountCollectionName { get; set; }
        public string? OrderCollectionName { get; set; }
        public string? ShakeCollectionName { get; set; }
    }
}
