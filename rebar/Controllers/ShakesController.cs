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
        private readonly IShakeService _shakeServise;

        public ShakesController(IShakeService shakeService) {

            _shakeServise = shakeService;
        }

        // GET: api/<ShakesController>
        [HttpGet]
        public ActionResult<List<Shake>> Get()
        {
            return _shakeServise.Get();
        }

        // GET api/<ShakesController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(Guid id)
        {
            var shake = _shakeServise.Get(id);

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
            _shakeServise.Creat(shake);

            return CreatedAtAction(nameof(Get), new { id = shake.Id }, shake);
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
            _shakeServise.Delete(id);
        }
    }
}
