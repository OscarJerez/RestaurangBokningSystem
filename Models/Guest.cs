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
public class GuestRepository
{
    public RestaurangBokningSystemContext resturangDB;
    public GuestRepository(RestaurangBokningSystemContext database)
    {
        resturangDB = database;
    }

    // Create
    public void AddGuest()
    {

        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();

        Console.WriteLine("What is your email?");
        string email = Console.ReadLine();

        Console.WriteLine("What is your phone number?");
        string phone = Console.ReadLine();

        Guest guest = new Guest()
        { Namn = name, Email = email, Telefonnummer = phone };

        guest.GuestsId = resturangDB.Guests.ToList().Count + 1; // Generera ett unikt ID

        resturangDB.Guests.Add(guest);

        resturangDB.SaveChanges();

    }

    // Read
    public List<Guest> GetAllGuests()

    {
        return resturangDB.Guests.ToList();
    }

    public Guest GetGuestById(int id)

    {
        return resturangDB.Guests.FirstOrDefault(guest => guest.GuestsId == id);
    }

    // Update
    public void UpdateGuest()

    {
        Console.Write("State Guest-ID to update: ");
        int id = int.Parse(Console.ReadLine());
        var guest = resturangDB.Guests.FirstOrDefault(b => b.GuestsId == id);
        if (guest != null)
        {
            Console.Write("State the updated name (leave blank to keep current): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) guest.Namn = name;

            Console.Write("State the updated email (leave blank to keep current): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) guest.Email = email;

            Console.Write("State the updated phone number (leave blank to keep current): ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrEmpty(phone)) guest.Telefonnummer = phone;

            resturangDB.Guests.Update(guest);

            resturangDB.SaveChanges();

            Console.WriteLine("The guest is updated.");
        }
        else
        {
            Console.WriteLine("Guest is not found.");

        }
    }
        // Delete
        public void DeleteGuest()

        {
            Console.Write("State guestID to remove: ");
            int id = int.Parse(Console.ReadLine());
            var guest = resturangDB.Guests.FirstOrDefault(a => a.GuestsId == id);
            if (guest != null)
            {
                resturangDB.Guests.Remove(guest);

                resturangDB.SaveChanges();

            Console.WriteLine("Guest is removed.");
            }
            else
            {
                Console.WriteLine("Guest is not found.");
            }
        }
}


