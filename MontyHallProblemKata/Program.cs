using System;

namespace MontyHallProblemKata
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var simulator = new Simulator();
            IRng rng = new Rng();
            

            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Monty Hall!\n");
            Console.ResetColor();
            var (switchingWins, switchingLosses) = simulator.PlayAllGames(rng, rng, true);
            var (stayingWins, stayingLosses) = simulator.PlayAllGames(rng, rng, false);
            var (switchWins, switchLosses, stayWins, stayLosses) = simulator.PlayAllGames(rng, rng);
            
            Console.WriteLine($"Switching \nWins: {switchingWins} \nLosses {switchingLosses}" );
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"Staying \nWins: {stayingWins} \nLosses {stayingLosses}" );
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"50% \nSwitch Wins: {switchWins} \nLosses {switchLosses} \nStay Wins: {stayWins} \nLosses {stayLosses}" );

        }
    }
}