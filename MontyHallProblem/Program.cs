
using System;
using System.Collections.Generic;
using MontyHallTests;

namespace MontyHallProblem
{
    internal class Program
    {
        private const int NumberOfGames = 1000;
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Monty Hall!\n");
            Console.ResetColor();
            var rng = new Rng();
            var montyHall = new MontyHall();
            var switching = PlayAllGames(true); 
            var staying = PlayAllGames(false);

            Console.WriteLine("Switching wins: " + switching.Item1 + "\nSwitching losses: " + switching.Item2);
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Staying wins: " + staying.Item1 + "\nStaying losses: " + staying.Item2);
        }

        public static (int, int) PlayAllGames(bool isPlayerSwitching)
        {
            //should sit in program
            var wins = 0;
            var losses = 0;
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();
                var doors = new List<Door> {new Door(), new Door(), new Door()};
                if (montyHall.PlayGame(isPlayerSwitching)) wins++;
                else losses++;
            }

            return (wins, losses);
        }
        }
    }

