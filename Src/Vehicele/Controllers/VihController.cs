using Microsoft.AspNetCore.Mvc;
using Vehicele.InfraStructure;
using Vehicele.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicele.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VihController : ControllerBase
    {
        private readonly IVichelecs _vs;
        public VihController(IVichelecs VS)
        {
            _vs = VS;
        }
        // GET: api/<VihController>
        [HttpGet]
        public async Task<IEnumerable<Vihicle>> Get()
        {
           return await _vs.GetAll();
        }

        // GET api/<VihController>/5
        [HttpGet("{id}")]
        public async Task <Vihicle> Get(int id)
        {
          var res = await _vs.GetById(id);
            return res; 
        }

        // POST api/<VihController>
        [HttpPost]
        public async Task Post([FromBody] Vihicle value)
        {
            await _vs.PostVihicle(value);
        }

        // PUT api/<VihController>/5
        [HttpPut("{id}")]
        public async Task<Vihicle>  Put(int id, [FromBody] Vihicle value)
        {
            var res = await _vs.UpdateVihicle(id, value);
            return res;
        }

        // DELETE api/<VihController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
           var res = await  _vs.DeleteVihicle(id);
            return res; 
        }
    }
}
