using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Player
    {
        public Door SelectRandomDoor(IRng rng, List<Door> doors)
        {
            var selection = rng.Next(0,3);
            doors[selection].IsSelected = true;
            var chosenDoor = doors[selection];
            return chosenDoor;
        }

        public Door SwitchDoor(IEnumerable<Door> doors)
        {
             var chosenDoor = doors.FirstOrDefault(x => !x.IsSelected);
             return chosenDoor;
        }
    }
}