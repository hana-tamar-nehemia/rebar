namespace rebar.Models
{
    public class ShakeDatabaseSettings:IShakeDatabaseSettings
    {
      public  string DatabaseName { get; set; } = String.Empty;
      public string ConnectionString { get; set; } = String.Empty;
      public string ShakeCollectionName { get; set; } = String.Empty;
    }
}