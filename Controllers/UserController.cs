using BLL.Interfaces;
using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBll bll;

        public UserController(IUserBll bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetAll()
        {
            return await this.bll.GetAll();
        }

        [HttpGet("{mail}/{password}")]
        public async Task<UserDTO> GetByMailAndPasword(string mail, string password)
        {
            return await this.bll.GetByMailAndPasword(mail, password);
        }

        [HttpPost]
        public async Task<int> Add(UserDTO userDTO)
        {
            return await this.bll.Add(userDTO);
        }

        [HttpDelete("{UserId}")]
        public async Task<bool> Delete(int UserId)
        {
            return await this.bll.Delete(UserId);
        }
        [HttpPut]
        public async Task<bool> Update(UserDTO user)
        {
            return await this.bll.Update(user);
        }
        [HttpGet("{userId}")]
        public async Task<List<TripDTO>> GetAllTripsByUser(int userId)
        {
            return await this.bll.GetAllTripsByUser(userId);
        }
    }
}
