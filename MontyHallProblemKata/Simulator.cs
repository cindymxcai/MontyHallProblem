namespace MontyHallProblemKata
{
    public static class Simulator
    {
        private const int NumberOfGames = 1000;
        private static int Wins { get; set; }
        private static int Losses { get; set; }

        public static (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, bool willPlayerSwitch)
        {
            Wins = 0;
            Losses = 0;
            PlayGameAndGetScore(doorToPlaceCar, doorToChoose, willPlayerSwitch);
            return (Wins, Losses);
        }

        public static (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, IRng willPlayerSwitch)
        {
            Wins = 0;
            Losses = 0;
            var percentageSwitches = willPlayerSwitch.Next(0, 1);
            PlayGameAndGetScore(doorToPlaceCar, doorToChoose, percentageSwitches == 0);
            return (Wins, Losses);
        }

        private static void PlayGameAndGetScore(IRng doorToPlaceCar, IRng doorToChoose, bool willPlayerSwitch)
        {
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();
                var switchPrize = montyHall.PlayGame(doorToPlaceCar, doorToChoose, willPlayerSwitch);
                if (switchPrize == Prize.Car)
                {
                    Wins++;
                }
                else
                {
                    Losses++;
                }
            }
        }
    }
}