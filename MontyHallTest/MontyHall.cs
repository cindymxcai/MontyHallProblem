using System;
using System.Collections.Generic;
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
    }

    public class Choice
    {
        public bool IsPrize = false;
        public bool IsSelected = false;
    }
}