using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
    public  class Player
    {
        public int SwitchingChances { get; }
        
        public Player(int isSwitching)
        { 
            SwitchingChances = isSwitching;
        }
        
        public void ChooseRandomDoor(IRng rng, List<Door> doors)
        {
            var choice = rng.Next(0, 3);
            doors[choice].IsChosen = true;
        }

        public void SwitchDoor(List<Door> doors, int willPlayerSwitch)
        {
            if (willPlayerSwitch == 0) return;
            var doorToSwitchTo = doors.FirstOrDefault(x => !x.IsOpened && !x.IsChosen);
            var chosenDoor = doors.FirstOrDefault(x => x.IsChosen);
            if (chosenDoor != null) chosenDoor.IsChosen = false;
            if (doorToSwitchTo != null) doorToSwitchTo.IsChosen = true;
        }
    }
}