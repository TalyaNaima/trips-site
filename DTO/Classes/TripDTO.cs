using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TripDTO
    {
        public int TripId { get; set; }

        public string Yhad { get; set; } = null!;

        public int TripTypeId { get; set; }

        public DateOnly TripDate { get; set; }

        public int TripTime { get; set; }

        public int TripDuration { get; set; }

        public int TripEmptyPlace { get; set; }

        public int Price { get; set; }

        public string Picture { get; set; } = null!;

       // public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

        //תוספת מהמסד

        //שם סוג
        public string TripTypeName { get; set; } = null!;
        //האם יש צורך בחובש
        public bool IsFirstAid { get; set; }
    }
}
