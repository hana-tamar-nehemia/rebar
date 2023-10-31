using rebar.Models;

namespace rebar.Services
{
    public interface IShakeService
    {
        List<Shake> Get(); 
        Shake Get(Guid shakeId);
        Shake Creat(Shake shake);   
        void Delete(Guid shakeId);    
    }
}
