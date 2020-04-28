namespace MontyHallProblemKata
{
    public class Simulator
    {
        private const int NumberOfGames = 1000;
        private int Wins { get; set; }
        private int Losses { get; set; }
        
        public (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, int willPlayerSwitch)
        {
            Wins = 0;
            Losses = 0;
            var player = new Player(willPlayerSwitch);
            PlayGameAndGetScore(doorToPlaceCar, doorToChoose, willPlayerSwitch);
            return (Wins, Losses);
        }

        private void PlayGameAndGetScore(IRng doorToPlaceCar, IRng doorToChoose, int willPlayerSwitch)
        {
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();
                var player = new Player(willPlayerSwitch);
                var prize = montyHall.PlayGame(doorToPlaceCar, doorToChoose, willPlayerSwitch);
                if (prize == Prize.Car)
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