using System;
using System.Collections.Generic;

namespace RestaurangBokningSystem.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string DishName { get; set; } = null!;

    public decimal Price { get; set; } 

    public string Type { get; set; } = null!;

    
}