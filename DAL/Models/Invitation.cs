using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Invitation
{
    public int InvitationId { get; set; }

    public int InvitationUserId { get; set; }

    public DateOnly InvitationDate { get; set; }

    public int InvitationTime { get; set; }

    public int InvitationTripId { get; set; }

    public int TripDuration { get; set; }

    public int PlaceNumber { get; set; }

    public virtual Trip InvitationTrip { get; set; } = null!;

    public virtual User InvitationUser { get; set; } = null!;
}
