using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblem
{
    public class Host
    {
        public Door DisplayRemainingDoorContainingNoPrize(IEnumerable<Door> doors)
        {
           var displayedDoor = doors.First(x => !x.IsPrize && !x.IsSelected);
           return displayedDoor;
        }
    }
}