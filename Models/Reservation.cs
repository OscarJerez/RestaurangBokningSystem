using System;
using System.Collections.Generic;

namespace RestaurangBokningSystem.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? TableId { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateOnly ReservationDate { get; set; }

    public TimeOnly ReservationTime { get; set; }

    public int NumberOfGuests { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Table? Table { get; set; }
}
