using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Trip
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

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

    public virtual TypeTrip TripType { get; set; } = null!;
}
