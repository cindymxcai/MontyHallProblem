using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Player
    {
        public Door SelectDoor(IRng rng, List<Door> doors)
        {
            var selection = rng.Next(0,3);
            doors[selection].IsSelected = true;
            var chosenDoor = doors[selection];
            return chosenDoor;
        }

        public Door SwitchDoor(IEnumerable<Door> doors)
        {
             var chosendoor = doors.FirstOrDefault(x => !x.IsSelected);
             return chosendoor;
        }
    }
}