using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITypeTripDAL
    {
        Task<List<TypeTrip>> GetAll();
        Task<TypeTrip> GetById(int id);
        Task<int> Add(TypeTrip typeTrip);
        Task<bool> Delete(int id);
    }
}
