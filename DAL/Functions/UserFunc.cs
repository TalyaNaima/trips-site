using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class UserFunc: IUserDAL
    {
        private readonly TripContext db;
        public UserFunc(TripContext db) 
        {
            this.db = db;
        }

        public async Task<int> Add(User user)
        {
            try
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                User? newUser = db.Users.FirstOrDefault(u =>
                u.FirstName == user.FirstName &&
                u.LastName == user.LastName &&
                u.Phone == user.Phone &&
                u.Email == user.Email &&
                u.Password == user.Password &&
                u.IsFirstAid == user.IsFirstAid
                );

                return newUser.UserId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                User user = await db.Users.FindAsync(id);
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return  db.Users.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetByMailAndPasword(string mail, string password)
        {
            try
            {
                User user = await db.Users
                    .FirstOrDefaultAsync(x => x.Email == mail && x.Password==password);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                User NewUser = await GetByMailAndPasword(user.Email, user.Password);
                if (NewUser != null)
                {
                    NewUser.FirstName = user.FirstName;
                    NewUser.LastName = user.LastName;
                    NewUser.Phone = user.Phone;
                    NewUser.Email = user.Email;
                    NewUser.Password = user.Password;
                    NewUser.IsFirstAid = user.IsFirstAid;
                    //
                    NewUser.Invitations = user.Invitations;

                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
