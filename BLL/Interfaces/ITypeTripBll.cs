using DAL.Models;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITypeTripBll
    {
        Task<List<TypeTripDTO>> GetAll();
        Task<TypeTripDTO> GetById(int id);
        Task<int> Add(TypeTripDTO typeTrip);
        Task<bool> Delete(int id);
    }
}
