
using System;


namespace MontyHallProblem
{
    internal static class Program
    {
        private const int NumberOfGames = 1000;
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Monty Hall!\n");
            Console.ResetColor();
            var switching = PlayAllGames(true); 
            var staying = PlayAllGames(false);

            Console.WriteLine("Switching wins: " + switching.Item1 + "\nSwitching losses: " + switching.Item2);
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Staying wins: " + staying.Item1 + "\nStaying losses: " + staying.Item2);
        }

        private static (int, int) PlayAllGames(bool isPlayerSwitching)
        {
            var wins = 0;
            var losses = 0;
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();
                if (montyHall.PlayGame(isPlayerSwitching)) wins++;
                else losses++;
            }

            return (wins, losses);
        }
        }
    }
//TODO: take playallgames in simulation class

