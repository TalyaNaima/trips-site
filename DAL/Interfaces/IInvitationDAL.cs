using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IInvitationDAL
    {
        List<Invitation> GetAll();
        Task<Invitation> GetById(int id);
        Task<int> Add(Invitation invitation);
        Task<bool> Delete(int id);

    }
}
