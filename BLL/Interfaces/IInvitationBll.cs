using DAL.Models;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IInvitationBll
    {
        Task<List<InvitationDTO>> GetAllInvitationsToTrip(int id);
        List<InvitationDTO> GetAll();
        Task<InvitationDTO> GetById(int id);
        Task<int> Add(InvitationDTO invitation);
        Task<bool> Delete(int id);
        Task<bool> Delete(int UId, int TId);
    }
}
