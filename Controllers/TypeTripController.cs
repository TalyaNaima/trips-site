using BLL.Interfaces;
using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeTripController : ControllerBase
    {
        ITypeTripBll bll;

        public TypeTripController(ITypeTripBll bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        public async Task<List<TypeTripDTO>> GetAll()
        {
            return await this.bll.GetAll();
        }

        [HttpGet("{TypeTripId}")]
        public async Task<TypeTripDTO> GetById(int TypeTripId)
        {
            return await this.bll.GetById(TypeTripId);
        }

        [HttpPost]
        public async Task<int> Add(TypeTripDTO typeTrip)
        {
            return await this.bll.Add(typeTrip);
        }

        [HttpDelete("{TypeTripId}")]
        public async Task<bool> Delete(int TypeTripId)
        {
            return await this.bll.Delete(TypeTripId);
        }
    }
}
