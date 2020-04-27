namespace MontyHallProblemKata
{
    public class Simulator
    {
        private const int NumberOfGames = 1000;
        private int Wins { get; set; }
        private int Losses { get; set; }

        public (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, bool willPlayerSwitch)
        {
            Wins = 0;
            Losses = 0;
            PlayGameAndGetScore(doorToPlaceCar, doorToChoose, willPlayerSwitch);
            return (Wins, Losses);
        }

        public (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, IRng willPlayerSwitch)
        {
            Wins = 0;
            Losses = 0;
            var player = new Player();
            var percentageSwitches = willPlayerSwitch.Next(0, 1);
            player.SwitchingTimes = percentageSwitches;
            PlayGameAndGetScore(doorToPlaceCar, doorToChoose, player.SwitchingTimes == 0);
            return (Wins, Losses);
        }

        private void PlayGameAndGetScore(IRng doorToPlaceCar, IRng doorToChoose, bool willPlayerSwitch)
        {
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();
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