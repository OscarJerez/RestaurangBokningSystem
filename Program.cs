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
                    // Fetch all guests from the database
                    var guests = ourDatabase.Guests;

                    // Print each guest
                    foreach (var guest in guests)
                    {
                        Console.WriteLine($"Guest ID: {guest.GuestsId}, Name: {guest.Namn}, Email: {guest.Email}, Phone: {guest.Telefonnummer}");
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
