using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class InvitationDTO
    {
        public int InvitationId { get; set; }

        public int InvitationUserId { get; set; }

        public DateOnly? InvitationDate { get; set; }

        public int? InvitationTime { get; set; }

        public int InvitationTripId { get; set; }

        public int? TripDuration { get; set; }

        public int PlaceNumber { get; set; }

        //תוספת מהמסד

        //שם פרטי ומשפחה של המשתמש בשדה אחד
        public string? InvitationUserName { get; set; } = null!;
        //יעד הטיול
        public string? InvitationTripYhad { get; set; } = null!;
        //תאריך הטיול
        public DateOnly? InvitationTripDate { get; set; }

    }
}
