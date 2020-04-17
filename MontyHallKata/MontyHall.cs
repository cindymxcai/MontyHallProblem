using System;
using System.Collections.Generic;
using System.Linq;
using MontyHallKata;

namespace MontyHallTest
{
    public class MontyHall
    {

        public void PlacePrize(IRng rng, List<Door> doors) 
        {
            doors[rng.Next(0,3)].IsPrize = true;
        }

        public bool PlayOneGame(IRng rng, bool isSwitching, List<Door> doors)
        {
             PlacePrize(rng,doors);
            
            var selection = rng.Next(0,3);
            doors[selection].IsSelected = true;
            var chosenDoor = doors[selection];
            
            var doorToDisplay = doors.FirstOrDefault(x => !x.IsSelected && !x.IsPrize);
            doors.Remove(doorToDisplay);

            if (isSwitching)
            {
                chosenDoor = doors.FirstOrDefault(x => !x.IsSelected);
           
            }

            return chosenDoor.IsPrize;
       
        }

        public (int,int) PlayAllGames(IRng rng, bool isSwitching, int games)
        {
            int wins = 0;
            int losses = 0; 
            for (int _ = 0; _ < games; _++) 
            {
                List<Door> doors = new List<Door>{new Door(), new Door(), new Door()};
                
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

    public class Door
    {
        public bool IsPrize = false;
        public bool IsSelected = false;
    }
}