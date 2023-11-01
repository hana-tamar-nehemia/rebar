using rebar.Models;

namespace rebar.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> Get();
        Task Creat(Account account);
    }
}
