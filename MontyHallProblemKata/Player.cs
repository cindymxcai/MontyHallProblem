using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
    public class Player
    {
        public Door ChosenDoor { get; private set; }
        public void ChooseRandomDoor(IRng rng, List<Door> doors)
        {
            var choice = rng.Next(0, 3);
            ChosenDoor = doors[choice];
            doors[choice].IsChosen = true;
        }

        public void SwitchDoor(IEnumerable<Door> doors, bool willPlayerSwitch)
        {
            if (!willPlayerSwitch) return;
            var switchedDoor = doors.FirstOrDefault(x => !x.IsOpened && !x.IsChosen);
            ChosenDoor.IsChosen = false;
            ChosenDoor =  switchedDoor;
            if (ChosenDoor != null) ChosenDoor.IsChosen = true;
        }
    }
}