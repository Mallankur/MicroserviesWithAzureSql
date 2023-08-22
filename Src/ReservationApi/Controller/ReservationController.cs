using Microsoft.AspNetCore.Mvc;
using ReservationApi.Infrasturcture.Domain;
using ReservationApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservation _res;
        public ReservationController(IReservation res )
        {
            _res = res;
        }
        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IEnumerable<Reservation>> Get()
        {
            var resultallresuration= await _res.GetAllReservation();
            return resultallresuration;
        }

        
       
     
        

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task  Put(int id)
        {
            await _res.UpdateMailStatus(id);
        }

       
    }
}
