using System;
using MontyHallTest;

namespace MontyHallKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Monty Hall!\n" );
            Console.ResetColor();
            var rng = new Rng();
            var montyHall = new MontyHall();
            var switching = montyHall.PlayAllGames(rng, true, 1000);
            var staying = montyHall.PlayAllGames(rng, false, 1000);
            
            Console.WriteLine("Switching wins: "+ switching + "\nSwitching losses: " + (1000-switching));
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Staying wins: " + staying + "\nStaying losses: " + (1000-staying));
            
        }
    }
}