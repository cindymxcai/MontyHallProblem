using System;

namespace MontyHallProblemKata
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IRng rng = new Rng();
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Monty Hall!\n");
            Console.ResetColor();
            var simulator = new Simulator();

            var (switchingWins, switchingLosses) = simulator.PlayAllGames(rng, rng, 1 );
            var (stayingWins, stayingLosses) = simulator.PlayAllGames(rng, rng, 0  );
            var (bothWins, bothLosses) = simulator.PlayAllGames(rng, rng, rng.Next(0,1));
            
            Console.WriteLine($"Switching \nWins: {switchingWins} \nLosses {switchingLosses}" );
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"Staying \nWins: {stayingWins} \nLosses {stayingLosses}" );
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"Random \nWins: {bothWins} \nLosses {bothLosses}" );

        }
    }
}