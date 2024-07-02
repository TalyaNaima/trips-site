using BLL.Interfaces;
using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        ITripBll bll;

        public TripController(ITripBll bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        public List<TripDTO> GetAll()
        {
            return  this.bll.GetAll();
        }

        [HttpGet("GetById/{TripId}")]
        public async Task<TripDTO> GetById(int TripId)
        {
            return await this.bll.GetById(TripId);
        }

        [HttpPost]
        public async Task<int> Add(TripDTO trip)
        {
            return await this.bll.Add(trip);
        }

        [HttpDelete("{TripId}")]
        public async Task<bool> Delete(int TripId)
        {
            return await this.bll.Delete(TripId);
        }
        [HttpPut]
        public async Task<bool> Update(TripDTO trip)
        {
            return await this.bll.Update(trip);
        }
        [HttpGet("GetInvitesToTrip/{tripId}")]
        public List<InvitationDTO> GetInvitesToTrip(int tripId)
        {
            return  bll.GetInvitesToTrip(tripId);
        }
    }
}
