using System.Collections.Generic;

namespace MontyHallKata
{
    public class MontyHall
    {
        public static bool PlayOneGame(IRng rng, bool isSwitching, List<Door> doors)
        {
            doors[rng.Next(0, 3)].IsPrize = true;
            var player = new Player();
            var chosenDoor = player.SelectRandomDoor(rng, doors);
            var host = new Host();
            host.DisplayUnselectedNonPrizeDoor(doors);
            
            if (isSwitching)
            {
                chosenDoor = player.SwitchDoor(doors);
            }

            return chosenDoor.IsPrize;
        }

        public static (int, int) PlayAllGames(IRng rng, bool isSwitching, int games)
        {
            //should sit in program
            var wins = 0;
            var losses = 0;
            for (var _ = 0; _ < games; _++)
            {
                var doors = new List<Door> {new Door(), new Door(), new Door()};
                if (PlayOneGame(rng, isSwitching, doors)) wins++;
                else losses++;
            }

            return (wins, losses);
        }
    }
}