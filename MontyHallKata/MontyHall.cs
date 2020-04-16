using System;
using System.Collections.Generic;
using System.Linq;
using MontyHallKata;

namespace MontyHallTest
{
    public class MontyHall
    {
        private readonly Rng _random = new Rng();
        public List<Choice> SetUpDoors()
        {
            List<Choice> choices = new List<Choice>{new Choice(), new Choice(), new Choice()};
            return choices;
        }

        public List<Choice> PlacePrize(IRng rng, List<Choice> doors)
        {
            doors[rng.Next(0,3)].IsPrize = true;
            return doors;
        }

        public bool PlayOneGame(IRng rng, bool isSwitching, List<Choice> doors)
        {
            var selection = rng.Next(0,3);
            
            var choices = PlacePrize(rng,doors);
            choices[selection].IsSelected = true;
            var chosenDoor = choices[selection];
            var displayDoor = rng.Next(0, 2);

            var doorToDisplay = choices.Where(x => !x.IsSelected && !x.IsPrize);
            var toDisplay = doorToDisplay as Choice[] ?? doorToDisplay.ToArray();
            var display = toDisplay.ElementAt(toDisplay.Count() == 1 ? 0 : displayDoor);
            choices.Remove(display);

            if (isSwitching)
            {
                var firstChoice = choices.FirstOrDefault(x => x.IsSelected);
                chosenDoor = choices.FirstOrDefault(x => !x.IsSelected);
                firstChoice.IsSelected = false;
                chosenDoor.IsSelected = true;
            }

            return chosenDoor.IsPrize;
       
        }

        public int PlayAllGames(IRng rng, bool isSwitching, int games)
        {
            int wins = 0;
            for (int i = 0; i < games; i++)
            {
                var doors = SetUpDoors();
                
                if (PlayOneGame(rng, isSwitching, doors))
                    wins++;
            }

            return wins;
        }
    }

    public class Choice
    {
        public bool IsPrize = false;
        public bool IsSelected = false;
    }
}