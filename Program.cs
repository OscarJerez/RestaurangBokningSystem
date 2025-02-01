using RestaurangBokningSystem.Models;

namespace RestaurangBokningSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            using (var ourDatabase = new RestaurangBokningSystemContext())
            {
                try
                {

                    // Fetch and display all guests from the database
                    var guests = ourDatabase.Guests.ToList();
                    GuestRepository guestRepository = new GuestRepository(ourDatabase);
                    guestRepository.AddGuest();
                    guestRepository.UpdateGuest();
                    guestRepository.DeleteGuest();
                    Console.WriteLine("Guests:");
                    Console.WriteLine("-----------------------------------------------------");
                    foreach (var guest in guests)
                    {
                        Console.WriteLine($"Guest ID: {guest.GuestsId}, Name: {guest.Namn}, Email: {guest.Email}, Phone: {guest.Telefonnummer}");
                    }

                    Console.WriteLine("\n");

                    // Fetch and display all menu items from the database
                    var menuItems = ourDatabase.Menus;
                    Console.WriteLine("Menu:");
                    Console.WriteLine("-----------------------------------------------------");
                    foreach (var menuItem in menuItems)
                    {
                        Console.WriteLine($"Menu ID: {menuItem.MenuId}, Dish: {menuItem.DishName}, Price: {menuItem.Price:C}, Type: {menuItem.Type}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while connecting to the database:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
