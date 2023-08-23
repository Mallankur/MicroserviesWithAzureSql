using CustomerApi.Infrastructure.Repo;
using CustomerApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Icustumer _cs;
        public CustomerController(Icustumer cs)
        {
            _cs = cs;
        }
        

        

        // POST api/<CustomerController>
        [HttpPost]
        public async Task  Post([FromBody] Customer  value)
        {
            await _cs.CreateAsync(value);
        }

       
        
        
    }
}
