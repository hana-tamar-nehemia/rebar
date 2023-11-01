using rebar.Models;

namespace rebar.Services
{
    public interface IShakeService
    {
        List<Shake> Get(); 
        Shake Get(string shakeId);
        Shake Creat(Shake shake);   
        void Delete(string shakeId);    
    }
}
