using System;
using RestaurangBokningSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurangBokningSystem
{
    public class MenuHandler
    {
        private readonly RestaurangBokningSystemContext _context;

        public MenuHandler()
        {
            _context = new RestaurangBokningSystemContext();
        }

        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("===== Restaurant Booking System =====");
                Console.WriteLine("1. Guest View");
                Console.WriteLine("2. Manager View");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowGuestMenu();
                        break;
                    case "2":
                        ShowManagerMenu();
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting program...\n");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.\n");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void ShowGuestMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Guest Menu =====");
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. View Available Tables");
            Console.WriteLine("3. Go Back");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ViewMenu();
                    break;
                case "2":
                    ViewAvailableTables();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        private void ShowManagerMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Manager Menu =====");
            Console.WriteLine("1. Make a Reservation");
            Console.WriteLine("2. Cancel a Reservation");
            Console.WriteLine("3. View All Reservations");
            Console.WriteLine("4. Go Back");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    MakeReservation();
                    break;
                case "2":
                    CancelReservation();
                    break;
                case "3":
                    ViewAllReservations();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        private void ViewMenu()
        {
            Console.WriteLine("\n===== Menu =====");
            var menuItems = _context.Menus.ToList();
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine($"Menu ID: {menuItem.MenuId}, Dish: {menuItem.DishName}, Price: {menuItem.Price:C}, Type: {menuItem.Type}");
            }
        }

        private void ViewAvailableTables()
        {
            Console.WriteLine("\n===== Table Availability =====");

            // Fetch all tables with their reservations
            var allTables = _context.Tables.Include(t => t.Reservations).ToList();

            // Check if there are any tables in the system
            if (allTables.Count == 0)
            {
                Console.WriteLine("No tables found in the system.");
                return;
            }

            // Separate tables into available and reserved lists
            var availableTables = allTables.Where(t => !t.Reservations.Any()).ToList();
            var reservedTables = allTables.Where(t => t.Reservations.Any()).ToList();

            // Display available tables
            Console.WriteLine("\n--- Available Tables ---");
            if (availableTables.Count > 0)
            {
                foreach (var table in availableTables)
                {
                    Console.WriteLine($"Table ID: {table.TableId}, Number: {table.TableNumber}, Capacity: {table.Capacity}, Status: Available");
                }
            }
            else
            {
                Console.WriteLine("No available tables at the moment.");
            }

            // Display reserved tables
            Console.WriteLine("\n--- Reserved Tables ---");
            if (reservedTables.Count > 0)
            {
                foreach (var table in reservedTables)
                {
                    Console.WriteLine($"Table ID: {table.TableId}, Number: {table.TableNumber}, Capacity: {table.Capacity}, Status: Reserved");
                }
            }
            else
            {
                Console.WriteLine("No reserved tables at the moment.");
            }
        }



        private void MakeReservation()
        {
            Console.WriteLine("\n===== Make a Reservation =====");
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine() ?? "Unknown";
            Console.Write("Enter number of guests: ");
            int numberOfGuests = int.Parse(Console.ReadLine() ?? "1");
            Console.Write("Enter table ID: ");
            int tableId = int.Parse(Console.ReadLine() ?? "1");

            var reservation = new Reservation
            {
                CustomerName = customerName,
                NumberOfGuests = numberOfGuests,
                TableId = tableId,
                ReservationDate = DateOnly.FromDateTime(DateTime.Today),
                ReservationTime = TimeOnly.FromDateTime(DateTime.Now),
                CreatedAt = DateTime.Now
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            Console.WriteLine("Reservation created successfully!");
        }

        private void CancelReservation()
        {
            Console.Write("Enter Reservation ID to cancel: ");
            int reservationId = int.Parse(Console.ReadLine() ?? "0");
            var reservation = _context.Reservations.Find(reservationId);

            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
                Console.WriteLine("Reservation cancelled successfully!");
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
        }

        private void ViewAllReservations()
        {
            Console.WriteLine("\n===== All Reservations =====");
            var reservations = _context.Reservations.Include(r => r.Table).ToList();
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"ID: {reservation.ReservationId}, Name: {reservation.CustomerName}, Table: {reservation.Table?.TableNumber}, Date: {reservation.ReservationDate}, Time: {reservation.ReservationTime}");
            }
        }
    }
}
