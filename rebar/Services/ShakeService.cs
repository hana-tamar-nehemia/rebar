using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rebar.Models;

namespace rebar.Services
{
    public class ShakeService : IShakeService
    {
        private readonly IMongoCollection<Shake> _shakeCollection;
        private readonly IOptions<DatabaseSettings> _settings;
        public ShakeService(IOptions<DatabaseSettings> settings)
        {
            _settings = settings;

            var mongoClient = new MongoClient(_settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_settings.Value.DatabaseName);
            _shakeCollection = mongoDatabase.GetCollection<Shake>
                (_settings.Value.ShakeCollectionName);
        }

        public List<Shake> Get()
        {
            return _shakeCollection.Find(shake => true).ToList();
        }

        public Shake Creat(Shake shake)
        {
            _shakeCollection.InsertOne(shake);    
            return shake;   
        }

        public void Delete(string shakeId)
        {
            throw new NotImplementedException();
        }

        public Shake Get(string shakeId)
        {
            return _shakeCollection.Find(shake => shake.Id == shakeId).FirstOrDefault();
        }

    }
}
