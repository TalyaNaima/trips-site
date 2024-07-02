using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class InvitationFunc : IInvitationDAL
    {
        private readonly TripContext db;
        public InvitationFunc(TripContext db)
        {
            this.db = db;
        }
        public async Task<int>? Add(Invitation invitation)
        {
            try
            {
                await db.Invitations.AddAsync(invitation);
                await db.SaveChangesAsync();
                Invitation? newInvitation = db.Invitations.FirstOrDefault(i =>
                i.InvitationUserId == invitation.InvitationUserId &&
                i.InvitationDate == invitation.InvitationDate &&
                i.InvitationTime == invitation.InvitationTime &&
                i.InvitationTripId == invitation.InvitationTripId &&
                i.TripDuration == invitation.TripDuration &&
                i.PlaceNumber == invitation.PlaceNumber);

                return newInvitation.InvitationId;
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
                Invitation invitation = await db.Invitations.FindAsync(id);
                db.Invitations.Remove(invitation);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Invitation> GetAll()
        {
            try
            {
                return  db.Invitations
                    .Include(i => i.InvitationTrip)
                    .Include(i => i.InvitationUser)
                    .ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Invitation> GetById(int id)
        {
            try
            {
                var invitation = await db.Invitations
                    .Include(i => i.InvitationTrip)
                    .Include(i => i.InvitationUser)
                    .FirstOrDefaultAsync(x => x.InvitationId == id);
                return invitation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
