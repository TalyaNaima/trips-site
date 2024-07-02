using DAL.Models;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITripBll
    {
        List<TripDTO> GetAll();
        Task<TripDTO> GetById(int id);
        Task<int> Add(TripDTO trip);
        Task<bool> Delete(int id);
        Task<bool> Update(TripDTO trip);
        List<InvitationDTO> GetInvitesToTrip(int id);
    }
}
