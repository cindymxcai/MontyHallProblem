using System.Collections.Generic;

namespace MontyHallProblemKata
{
    public class Door //TODO find better name 
    {
        public bool IsPrize;
        public bool IsChosen;
        public bool IsOpened;
        
        public List<Door> Doors = new List<Door>();
        public List<Door> SetUpThreeDoors()
        {
            Doors = new List<Door> {new Door(), new Door(), new Door()};
            return Doors;
        }
        
        public void PlacePrize(IRng rng, List<Door> doors)
        {
            var door = rng.Next(0, 3);
            doors[door].IsPrize = true;
        }
    }
}