using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Classes;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Functions
{
    public class InvitationFuncBll : IInvitationBll
    {
        IInvitationDAL dal;
        DAL.Interfaces.ITripDAL tripsBLL;
        DAL.Interfaces.IUserDAL UserDAL;
        IMapper mapper;

        public InvitationFuncBll(IInvitationDAL dal, ITripDAL tripDAL, IUserDAL userDAL)
        {
            this.dal = dal;
            this.tripsBLL = tripDAL;
            this.UserDAL = userDAL;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Classes.Mapper>();
            });

            mapper = config.CreateMapper();
            UserDAL = userDAL;
        }

        public async Task<int> Add(InvitationDTO invitation)
        {
            ////בדיקה האם המשתמש יש לו תעודת עזרה ראשונה

            ////שליפת כל המשתמשים
            //var users = UserDAL.GetAll();

            //// שליפת המשתמש שרוצה להזמין
            //var thisUser = users.FirstOrDefault(u => u.UserId == invitation.InvitationUserId);

            //שליפת כל הטיולים
            var trips = tripsBLL.GetAll();

            //שליפת הטיול שרוצים להזמין לו מקום
            var thisTrip = trips.FirstOrDefault(t => t.TripId == invitation.InvitationTripId);



            //בדיקה שתאריך הטיול עדיין לא עבר ושיש מספיק מקומות פנויים
            if (thisTrip != null && thisTrip.TripEmptyPlace > invitation.PlaceNumber
                && thisTrip.TripDate.CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0)
            {
                //עדכון התאריך והשעה הנוכחיים
                invitation.InvitationDate = DateOnly.FromDateTime(DateTime.Now);
                invitation.InvitationTime = DateTime.Now.Hour;

                int code = await dal.Add(mapper.Map<InvitationDTO, Invitation>(invitation));

                ////אם יש לו תעודת עזרה ראשונה
                //if (thisUser != null)
                //{
                //    var thisTripDTO = mapper.Map<Trip, TripDTO>(thisTrip);
                //    if (thisUser.IsFirstAid == true)
                //    {
                //        thisTripDTO.IsFirstAid = true;
                //        tripsBLL.Update(thisTripDTO);
                //    }
                //}

                //עדכון המקומות הפנוים בטיול 
                thisTrip.TripEmptyPlace = thisTrip.TripEmptyPlace - invitation.PlaceNumber;
                //נשלח אותו לעדכון
                bool x=await tripsBLL.Update(thisTrip, thisTrip.TripId);
                if (x == true)
                    return code;
                else return -1;
            }
            return -1;
        }

        public async Task<bool> Delete(int id)
        {
            //שליפת ההזמנה 
            var invitations =  dal.GetAll();
            var thisInvitation = invitations.FirstOrDefault(o => o.InvitationId == id);
            //שליפת כל הטיולים
            var trips = tripsBLL.GetAll();
            //שליפת הטיול שרוצים למחוק את ההזמנות שלו
            var thisTrip = trips.FirstOrDefault(t => t.TripId == thisInvitation.InvitationTripId);
            //בדיקה שלא עבר תאריך הטיול
            if (thisTrip.TripDate.CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0)
            {
                //עדכון מקומות פנוים בטיול 
                thisTrip.TripEmptyPlace = thisTrip.TripEmptyPlace + thisInvitation.PlaceNumber;
                await tripsBLL.Update(thisTrip, thisTrip.TripId);
                return await dal.Delete(id);
            }
            return false;
        }
        public async Task<bool> Delete(int UId, int TId)
        {
            var invitations = dal.GetAll();
            var thisInvitation = invitations.FirstOrDefault(o => o.InvitationUserId==UId && o.InvitationTripId==TId);
            if(thisInvitation==null) return false;
            return await Delete(thisInvitation.InvitationId);

        }
        public List<InvitationDTO> GetAll()
        {
            List<Invitation> u =  dal.GetAll();
            if (u != null)
            {
                return mapper.Map<List<Invitation>, List<InvitationDTO>>(u);
            }
            return null;
        }

        public async Task<InvitationDTO> GetById(int id)
        {
            Invitation u = await dal.GetById(id);
            if (u != null)
            {
                return mapper.Map<Invitation, InvitationDTO>(u);
            }
            return null;
        }


        //מקבל קוד משתמש ומחזיר את כל ההזמנות לטיול זה
        public async Task<List<InvitationDTO>> GetAllInvitationsToTrip(int id)
        {
            var list =  dal.GetAll();
            list = list.FindAll(e => e.InvitationUserId == id);
            return mapper.Map<List<InvitationDTO>>(list);
        }
    }
}
