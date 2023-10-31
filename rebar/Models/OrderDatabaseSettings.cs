namespace rebar.Models
{
    public class OrderDatabaseSettings : IOrderDatabaseSettings
    {
        public string DatabaseName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string OrderCollectionName { get; set; } = String.Empty;
    }
}
