using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace RestaurangBokningSystem.Models;

public partial class Guest
{
    public int GuestsId { get; set; }

    public string Namn { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefonnummer { get; set; } = null!;
}
