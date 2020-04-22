namespace MontyHallProblemKata
{
    public class Simulator
    {
        private const int NumberOfGames = 1000; 
        public (int, int) PlayAllGames(IRng prize, IRng choice, bool willPlayerSwitch)
        {
            var wins = 0;
            var losses = 0;
            
            for (var _ = 0; _ < NumberOfGames; _++)
            {
                var montyHall = new MontyHall();

                if (montyHall.PlayGame(prize, choice, willPlayerSwitch))
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