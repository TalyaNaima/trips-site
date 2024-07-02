using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Classes;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Functions
{
    public class UserFuncBll: IUserBll
    {
        IUserDAL dal;
        private readonly DAL.Interfaces.IInvitationDAL invitationDAL;
        private readonly DAL.Interfaces.ITripDAL tripDAL;
        IMapper mapper;

        public UserFuncBll(IUserDAL dal, IInvitationDAL invitationDAL, ITripDAL tripDAL)
        { 
            this.dal = dal;
            this.invitationDAL = invitationDAL;
            this.tripDAL = tripDAL;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Classes.Mapper>();
            });

            mapper = config.CreateMapper();
        }

        public async Task<int> Add(UserDTO user)
        {
            //אם כל בדיקות התקינות נכונות
            if (MiddleWares.CheckName(user.FirstName) &&
                MiddleWares.CheckName(user.LastName) &&
                MiddleWares.CheckEmail(user.Email) &&
                MiddleWares.CheckPassword(user.Password) &&
                MiddleWares.CheckPhone(user.Phone))
            {
                int code = await dal.Add(mapper.Map<UserDTO, User>(user));
                return code;
            }
            return -1;
        }


        public async Task<bool> Delete(int id)
        {
            var list=await GetAll();
            UserDTO user = list.FirstOrDefault(u=>u.UserId == id);
            if (user == null) 
            {
                return false;
            }


            //שליפת כל ההזמנות
            List<Invitation> listInvit = invitationDAL.GetAll();
            //השארת כל ההזמנות שהמשתמש ביצע
            listInvit = listInvit.FindAll(u => u.InvitationUserId ==user.UserId);

            //אם לא רשום על שמו טיולים ניתן למחוק אותו
            if (listInvit.Count==0)
            {
                bool x = await dal.Delete(id);
                return x;
            }
            return false;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            List<User> u= dal.GetAll();
            if(u!=null)
            {
                return mapper.Map<List<User>, List<UserDTO>>(u);
            }
            return null;
        }

        public async Task<List<TripDTO>> GetAllTripsByUser(int UserId)
        {
            //השארת כל ההזמנות שהמשתמש ביצע
            List<Invitation> userInvitations = invitationDAL.GetAll().FindAll(u => u.InvitationUserId == UserId);

            //השארת כל הטיולים שהמשתמש הזמין להם מקומות
            List<Trip> availableTrips = new List<Trip>();
            foreach (var trip in tripDAL.GetAll())
            {
                bool userHasBooked = userInvitations.Exists(invitation => invitation.InvitationTripId == trip.TripId);
               // if (trip.TripEmptyPlace > 0 && !userHasBooked)
                    if (userHasBooked)
                {
                    availableTrips.Add(trip);
                }
            }


            return mapper.Map< List<Trip> ,List<TripDTO>>(availableTrips);
        }

        public async Task<UserDTO> GetByMailAndPasword(string mail, string password)
        {
            User u=await dal.GetByMailAndPasword(mail, password);
            if(u!=null)
            {
                return mapper.Map<User, UserDTO>(u);
            }
            return null;
        }

        public async Task<bool> Update(UserDTO user)
        {
            //אם כל בדיקות התקינות נכונות
            if (MiddleWares.CheckName(user.FirstName) &&
                MiddleWares.CheckName(user.LastName) &&
                MiddleWares.CheckEmail(user.Email) &&
                MiddleWares.CheckPassword(user.Password) &&
                MiddleWares.CheckPhone(user.Phone))
            {
                bool x = await dal.Update(mapper.Map<UserDTO, User>(user));
                return x;
            }
            return false;
        }
    }
}
