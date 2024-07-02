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
    public class TypeTripFunc :ITypeTripDAL
    {
        private readonly TripContext db;
        public TypeTripFunc(TripContext db)
        { 
            this.db = db;
        }

        public async Task<int> Add(TypeTrip typeTrip)
        {
            try
            {
                await db.TypeTrips.AddAsync(typeTrip);
                await db.SaveChangesAsync();
                TypeTrip? newTypeTrip = db.TypeTrips.FirstOrDefault(t =>
                t.TypeName==typeTrip.TypeName);

                return newTypeTrip.TypeId;
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
                TypeTrip typeTrip = await db.TypeTrips.FindAsync(id);
                db.TypeTrips.Remove(typeTrip);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TypeTrip>> GetAll()
        {
            try
            {
                return await db.TypeTrips.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TypeTrip> GetById(int id)
        {
            try
            {
                var typeTrip = await db.TypeTrips
                    .FirstOrDefaultAsync(x => x.TypeId == id);
                return typeTrip;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
