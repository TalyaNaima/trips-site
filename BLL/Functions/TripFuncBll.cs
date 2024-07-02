using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Classes;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Functions
{
    public class TripFuncBll : ITripBll
    {
        ITripDAL dal;
        private readonly DAL.Interfaces.IInvitationDAL invitationDAL;
        private readonly DAL.Interfaces.IUserDAL userDAL;
        IMapper mapper;

        public TripFuncBll(ITripDAL dal, IInvitationDAL invitationDAL, IUserDAL userDAL)
        {
            this.dal = dal;
            this.invitationDAL = invitationDAL;
            this.userDAL = userDAL;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Classes.Mapper>();
            });

            mapper = config.CreateMapper();
            this.userDAL = userDAL;
        }

        public async Task<int> Add(TripDTO trip)
        {
            //התאריך צריך להיות בין התאריך של היום ועד שלושה חודשים מהתאריך של היום
            //מחזיר ערך שלילי אם  התאריך מוקדם יותר מהערך שהתקבל
            int today = trip.TripDate.CompareTo(DateOnly.FromDateTime(DateTime.Now));//צריך להיות ערך חיובי
            int inThreeMonth = trip.TripDate.CompareTo(DateOnly.FromDateTime(DateTime.Now.AddMonths(3)));//צריך להיות ערך שלילי
            if (trip.TripDuration >= 3 && trip.TripDuration <= 12 &&
                trip.TripEmptyPlace > 0 &&
                trip.Price > 0 && trip.Price <= 500 &&
                today > 0 && inThreeMonth < 0)
            {
                int code = await dal.Add(mapper.Map<TripDTO, Trip>(trip));
                return code;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            bool x = await dal.Delete(id);
            return x;
        }

        public List<TripDTO> GetAll()
        {
            List<Trip> tripList = dal.GetAll();
            if (tripList != null)
            {
                var listDto= mapper.Map<List<Trip>, List<TripDTO>>(tripList);

                //מעבר על כל הטיולים
                for(int i = 0;i<listDto.Count;i++)
                {

                    bool firstAid = false;
                    //שליפת כל המשתמשים
                    var allUsers = userDAL.GetAll();
                    //השארת המשתמשים שיש להם תעודת עזרה ראשונה
                    allUsers = allUsers.FindAll(x => x.IsFirstAid == true);
                    //שליפת כל ההזמנות
                    var allInvitation = invitationDAL.GetAll();
                    //השארת כל ההזמנות של הטיול הזה
                    allInvitation = allInvitation.FindAll(o => o.InvitationTripId == listDto[i].TripId);

                    //מעבר על כל ההזמנות ובדיקה האם לאחד המשתמשים יש תעודת עזרה ראשונה
                    for (int x = 0; x < allInvitation.Count; x++)
                    {
                        for (int j = 0; j < allUsers.Count; j++)
                            if (allInvitation[x].InvitationUserId == allUsers[j].UserId)
                                listDto[i].IsFirstAid = true;
                    }
                }
                return listDto;

                }
            return null;
        }

        public async Task<TripDTO> GetById(int id)
        {
            bool firstAid=false;
            Trip u = await dal.GetById(id);
            if (u != null)
            {
                //שליפת כל המשתמשים
                var allUsers = userDAL.GetAll();
                //השארת המשתמשים שיש להם תעודת עזרה ראשונה
                allUsers = allUsers.FindAll(x => x.IsFirstAid == true);

                //שליפת כל ההזמנות
                var allInvitation = invitationDAL.GetAll();
                //השארת כל ההזמנות של הטיול הזה
                allInvitation = allInvitation.FindAll(o => o.InvitationTripId == u.TripId);
                //מעבר על כל ההזמנות ובדיקה האם לאחד המשתמשים יש תעודת עזרה ראשונה
                for (int i = 0;i<allInvitation.Count;i++)
                {
                    for(int j = 0;j<allUsers.Count;j++)
                        if (allInvitation[i].InvitationUserId == allUsers[j].UserId)
                           firstAid = true;
                }

                //הצבת הערך של תעודת עזרה ראשונה

                var tripDto= mapper.Map<Trip, TripDTO>(u);
                tripDto.IsFirstAid = firstAid;
                return tripDto;

            }
            return null;
        }

        //מחזיר את רשימת ההזמנות לטיול כולל שם המזמין
        public List<InvitationDTO> GetInvitesToTrip(int tripId)
        {
            //שליפת כל ההזמנות
            var list =  invitationDAL.GetAll();
            list = list.FindAll(o => o.InvitationTripId == tripId);
            if (list.Count!=0)
                return mapper.Map<List<InvitationDTO>>(list);
            return new List<InvitationDTO>();
        }

        public async Task<bool> Update(TripDTO trip)
        {
            //התאריך צריך להיות בין התאריך של היום ועד שלושה חודשים מהתאריך של היום
            //מחזיר ערך שלילי אם  התאריך מוקדם יותר מהערך שהתקבל
            int today = trip.TripDate.CompareTo(DateOnly.FromDateTime(DateTime.Now));//צריך להיות ערך חיובי
            int inThreeMonth = trip.TripDate.CompareTo(DateOnly.FromDateTime(DateTime.Now.AddMonths(3)));//צריך להיות ערך שלילי
            if (trip.TripDuration >= 3 && trip.TripDuration <= 12 &&
               trip.TripEmptyPlace > 0 &&
               trip.Price > 0 && trip.Price <= 500 &&
                today > 0 && inThreeMonth < 0)
            {
                int tripId = trip.TripId;
                bool x = await dal.Update(mapper.Map<TripDTO, Trip>(trip), tripId);
                return x;
            }
            return false;
        }


    }
}
