using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
    public class Host
    {
        public void OpenUnselectedDoorThatIsGoat(IEnumerable<Door> doors)
        {
            var openDoor = doors.FirstOrDefault(x => !x.IsChosen && x.Prize == Prize.Goat);
            if (openDoor != null) openDoor.IsOpened = true;
        }
    }
}