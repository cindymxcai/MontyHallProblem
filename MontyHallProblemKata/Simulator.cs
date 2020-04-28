namespace MontyHallProblemKata
{
    public class Simulator
    {
        private const int NumberOfGames = 1000;
        private int Wins { get; set; }
        private int Losses { get; set; }
        
        public (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, double switchingChance)
        {
            Wins = 0;
            Losses = 0;
            PlayGameAndGetScore(doorToPlaceCar, doorToChoose, switchingChance);
            return (Wins, Losses);
        }

        private void PlayGameAndGetScore(IRng doorToPlaceCar, IRng doorToChoose,  double switchingChance)
        {
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();
                var player = new Player(doorToChoose, switchingChance);
                var prize = montyHall.PlayGame(doorToPlaceCar, player);
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