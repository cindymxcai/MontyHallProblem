using System;
using System.Collections.Generic;
using MontyHallProblem;

namespace MontyHallTests
{
    public class MontyHall
    {
        public List<Door> Doors = new List<Door>{new Door(), new Door(), new Door()};
        Rng rng = new Rng();

        public void PlayGame()
        {
            Doors[rng.Next(0, 3)].IsPrize = true;
        }
    }
}