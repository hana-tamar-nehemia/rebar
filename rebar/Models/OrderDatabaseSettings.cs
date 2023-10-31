namespace rebar.Models
{
    public class OrderDatabaseSettings : IOrderDatabaseSettings
    {
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string OrderCollectionName { get; set; } = string.Empty;
    }
}
