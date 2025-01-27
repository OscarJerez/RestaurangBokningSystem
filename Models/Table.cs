using System;
using System.Collections.Generic;

namespace RestaurangBokningSystem.Models;

public partial class Table
{
    public int TableId { get; set; }

    public int TableNumber { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
