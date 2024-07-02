using DAL.Models;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBll
    {
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetByMailAndPasword(string mail, string password);
        Task<int> Add(UserDTO user);
        Task<bool> Delete(int id);
        Task<bool> Update(UserDTO user);
        Task<List<TripDTO>> GetAllTripsByUser(int id);
    }
}
