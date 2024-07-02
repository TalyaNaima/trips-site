using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TypeTripDTO
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; } = null!;

        //public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
