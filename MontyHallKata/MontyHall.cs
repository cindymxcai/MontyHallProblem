using System.Collections.Generic;

namespace MontyHallKata
{
    public class MontyHall
    {
        public static void PlacePrize(IRng rng, List<Door> doors) 
        {
            doors[rng.Next(0,3)].IsPrize = true;
        }

        public static bool PlayOneGame(IRng rng, bool isSwitching, List<Door> doors)
        {
             PlacePrize(rng,doors);
             
             var player = new Player();
             var chosenDoor = player.SelectDoor(rng, doors);
             
             var host = new Host();
             host.DisplayDoor(doors);
             
            if (isSwitching)
            {
                chosenDoor = player.SwitchDoor(doors);
            }

            return chosenDoor.IsPrize;
       
        }

        public static (int,int) PlayAllGames(IRng rng, bool isSwitching, int games)
        {
            int wins = 0;
            int losses = 0; 
            for (int _ = 0; _ < games; _++) 
            {
                var doors = new List<Door>{new Door(), new Door(), new Door()};
                
                if (PlayOneGame(rng, isSwitching, doors))
                    wins++;
                else
                {
                    losses++;
                }
            }
            return (wins, losses);
        }
    }
}