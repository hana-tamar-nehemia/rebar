using rebar.Models;

namespace rebar.Services
{
    public interface IAccountService
    {
        List<Account> Get();
        Task Creat(Account account);
    }
}
