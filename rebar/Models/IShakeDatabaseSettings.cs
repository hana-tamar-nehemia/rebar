namespace rebar.Models
{
    public interface IShakeDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string ShakeCollectionName { get; set; }


    }
}
