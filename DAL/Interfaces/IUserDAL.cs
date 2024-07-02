using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        List<User> GetAll();
        Task<User> GetByMailAndPasword(string mail, string password);
        Task<int> Add(User user);
        Task<bool> Delete(int id);
        Task<bool> Update(User user);
    }
}
