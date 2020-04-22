using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
    public class Host
    {
        public void OpenUnselectedDoorThatIsntPrize(IEnumerable<Door> doors)
        {
            var openDoor = doors.FirstOrDefault(x => !x.IsChosen && !x.IsPrize);
            if (openDoor != null) openDoor.IsOpened = true;
        }
    }
}