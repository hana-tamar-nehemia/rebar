namespace rebar.Models
{
    public interface IOrderDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string OrderCollectionName { get; set; }

    }
}
