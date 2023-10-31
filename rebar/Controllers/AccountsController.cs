using Microsoft.AspNetCore.Mvc;
using rebar.Models;
using rebar.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IAccountService _accountServise;

        public AccountsController(IAccountService accountService)
        {

            _accountServise = accountService;
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public ActionResult<List<Account>> Get()
        {
            return _accountServise.Get();
        }
       /* public async Task<IActionResult> Get()
        {
            var accounts = await _accountServise.Get();
            return Ok(accounts);
        }*/

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account account)
        {
            await _accountServise.Creat(account);
            return Ok("creat succesfuly"); 
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
