using System.Collections.Generic;
using System.Linq;

namespace MontyHallKata
{
    public class Host
    {
        public void DisplayUnselectedNonPrizeDoor(List<Door> doors)
        {
            var doorToDisplay = doors.FirstOrDefault(x => !x.IsSelected && !x.IsPrize);
            doors.Remove(doorToDisplay);
        }
    }
}