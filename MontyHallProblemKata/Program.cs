using System;

namespace MontyHallProblemKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var simulator = new Simulator();
            IRng rng = new Rng();
            var switching =simulator.PlayAllGames(rng, rng, true);
            var staying = simulator.PlayAllGames(rng, rng, false);

            Console.WriteLine($"Switching wins: {switching.Item1} and losses {switching.Item2}" );
            Console.WriteLine($"Staying wins: {staying.Item1} and losses {staying.Item2}" );

        }
    }
}