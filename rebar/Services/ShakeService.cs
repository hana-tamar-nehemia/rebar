using MongoDB.Driver;
using rebar.Models;

namespace rebar.Services
{
    public class ShakeService : IShakeServise
    {
        private readonly IMongoCollection<Shake> _shake;

        public ShakeService(IShakeDatabaseSettings settings, IMongoClient mongoClient) {

          var database = mongoClient.GetDatabase(settings.DatabaseName);

          _shake =  database.GetCollection<Shake>(settings.ShakeCollectionName);

        }

        public List<Shake> Get()
        {
            return _shake.Find(shake => true).ToList();
        }

        public Shake Creat(Shake shake)
        {
            _shake.InsertOne(shake);    
            return shake;   
        }

        public void Delete(Guid shakeId)
        {
            throw new NotImplementedException();
        }

        public Shake Get(Guid shakeId)
        {
            return _shake.Find(shake => shake.Id == shakeId).FirstOrDefault();
        }

    }
}
