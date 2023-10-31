namespace rebar.Models
{
    public class ShakeDatabaseSettings : IShakeDatabaseSettings
    {
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string ShakeCollectionName { get; set; } = string.Empty;
    }
}