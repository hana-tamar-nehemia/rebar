using Microsoft.AspNetCore.Mvc;
using rebar.Models;
using rebar.Services;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShakesController : ControllerBase
    {
        private readonly IShakeServise shakeServise;

        public ShakesController(IShakeServise shakeServise) {

            this.shakeServise = shakeServise;
        }

        // GET: api/<ShakesController>
        [HttpGet]
        public ActionResult<List<Shake>> Get()
        {
            return shakeServise.Get();
        }

        // GET api/<ShakesController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(Guid id)
        {
            //Guid guidId = new Guid(id);
            var shake = shakeServise.Get(id);

            if(shake == null) 
            {
                return NotFound($"shake with id = {id} not found");
            }
            return shake;
        }

        // POST api/<ShakesController>
        [HttpPost]
        public ActionResult<Shake> Post([FromBody] Shake shake)
        {
            shakeServise.Creat(shake);

            return CreatedAtAction(nameof(Get), new { id = shake.GetId() }, shake);
        }

        // PUT api/<ShakesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShakesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            shakeServise.Delete(id);
        }
    }
}
