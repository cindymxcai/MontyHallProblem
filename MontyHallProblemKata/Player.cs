using System;
using System.Collections.Generic;
using MontyHallProblemKata;

namespace MontyHallKataTests
{
    public class Player
    {
        public void ChooseRandomDoor(IRng rng, List<Door> doors)
        {
            var choice = rng.Next(0, 3); 
            doors[choice].IsChosen = true;
        }
    }
}