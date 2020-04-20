using System;

namespace MontyHallKata
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //define 1000 as constant for meaning
            //use comments for readability (eg for overview of a clasS)

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Monty Hall!\n");
            Console.ResetColor();
            var rng = new Rng();
            var montyHall = new MontyHall();
            var switching = MontyHall.PlayAllGames(rng, true, 1000);
            var staying = MontyHall.PlayAllGames(rng, false, 1000);

            Console.WriteLine("Switching wins: " + switching.Item1 + "\nSwitching losses: " + switching.Item2);
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Staying wins: " + staying.Item1 + "\nStaying losses: " + staying.Item2);
        }
    }
}