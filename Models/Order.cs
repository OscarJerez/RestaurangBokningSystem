using System;
using System.Collections.Generic;

namespace RestaurangBokningSystem.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ReservationId { get; set; }

    public int? MenuId { get; set; }

    public int Quantity { get; set; }
}
