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
    public class TripFunc : ITripDAL
    {
        private readonly TripContext db;
        public TripFunc(TripContext db)
        {
            this.db = db;
        }
        public async Task<int> Add(Trip trip)
        {
            try
            {
                await db.Trips.AddAsync(trip);
                await db.SaveChangesAsync();
                Trip? newTrip = db.Trips.FirstOrDefault(i =>
                i.Yhad == trip.Yhad &&
                i.TripTypeId == trip.TripTypeId &&
                i.TripDate == trip.TripDate &&
                i.TripTime == trip.TripTime &&
                i.TripDuration == trip.TripDuration &&
                i.TripEmptyPlace == trip.TripEmptyPlace &&
                i.Price == trip.Price &&
                i.Picture == trip.Picture
                );

                return newTrip.TripId;
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
                Trip trip = await db.Trips.FindAsync(id);
                db.Trips.Remove(trip);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Trip> GetAll()
        {
            try
            {
                return  db.Trips.Include(t => t.TripType).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Trip> GetById(int id)
        {
            try
            {
                Trip trip = await db.Trips.FirstOrDefaultAsync(t => t.TripId == id);
                return trip;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(Trip trip, int tripId)
        {
            try
            {
                Trip NewTrip = await GetById(tripId);
                if (NewTrip != null)
                {
                    NewTrip.Yhad = trip.Yhad;
                    NewTrip.TripTypeId = trip.TripTypeId;
                    NewTrip.TripDate = trip.TripDate;
                    NewTrip.TripTime = trip.TripTime;
                    NewTrip.TripDuration = trip.TripDuration;
                    NewTrip.TripEmptyPlace = trip.TripEmptyPlace;
                    NewTrip.Price = trip.Price;
                    NewTrip.Picture = trip.Picture;
                    //
                    NewTrip.Invitations = trip.Invitations;
                    NewTrip.TripType = trip.TripType;
                    

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
