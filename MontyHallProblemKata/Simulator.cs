namespace MontyHallProblemKata
{
    public class Simulator
    {
        private const int NumberOfGames = 1000;
        private const double PercentageToSwitch = 0.5;

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

        public (int, int) PlayAllGames(IRng doorToPlaceCar, IRng doorToChoose, IRng willPlayerSwitch)
        {
            var switchWins = 0;
            var switchLosses = 0;
            var percentageSwitches = willPlayerSwitch.Next(0, 1);
            var montyHall = new MontyHall();
            for (var __ = 0; __ < NumberOfGames; __++)
            {
                if (percentageSwitches == 0)
                {
                    var switchPrize = montyHall.PlayGame(doorToPlaceCar, doorToChoose, true);
                    if (switchPrize == Prize.Car)
                    {
                        switchWins++;
                    }
                    else
                    {
                        switchLosses++;
                    }
                }
                else
                {
                    var switchPrize = montyHall.PlayGame(doorToPlaceCar, doorToChoose, false);
                    if (switchPrize == Prize.Car)
                    {
                        switchWins++;
                    }
                    else
                    {
                        switchLosses++;
                    }
                }
            }

            return (switchWins, switchLosses);
        }

        //new method getGameScore
        //which above will call?
    }
}