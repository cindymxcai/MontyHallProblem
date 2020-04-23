namespace MontyHallProblemKata
{
    public class Simulator
    {
        private const int NumberOfGames = 1000; 
        public (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, bool willPlayerSwitch)
        {
            var wins = 0;
            var losses = 0;
            
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();
                var prize = montyHall.PlayGame(doorToPlaceCar, doorToChoose, willPlayerSwitch);
                if (prize == Prize.Car)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }

            return (wins, losses);
        }
    }
}