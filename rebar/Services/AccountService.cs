using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rebar.Models;

namespace rebar.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMongoCollection<Account> _accountCollection;
        private readonly IOptions<DatabaseSettings> _settings;
        public AccountService(IOptions<DatabaseSettings> settings)
        {
            _settings = settings;

            var mongoClient = new MongoClient(_settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_settings.Value.DatabaseName);
            _accountCollection = mongoDatabase.GetCollection<Account>
                (_settings.Value.AccountCollectionName);
        }
 /*       public List<Account> Get()
        {
            return _accountCollection.Find( account => true).ToList();
        }*/
        public async Task<IEnumerable<Account>> Get()=>
            await _accountCollection.Find( account => true).ToListAsync();
      
        public async Task Creat(Account account) =>
         await _accountCollection.InsertOneAsync(account);

    }
}
