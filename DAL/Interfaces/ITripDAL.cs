using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITripDAL
    {
        List<Trip> GetAll();
        Task<Trip> GetById(int id);
        Task<int> Add(Trip trip);
        Task<bool> Delete(int id);
        Task<bool> Update(Trip trip, int tripId);
    }
}
