using System;
using RestaurangBokningSystem;

namespace RestaurangBokningSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuHandler menuHandler = new MenuHandler();
            menuHandler.ShowMenu();
        }
    }
}
