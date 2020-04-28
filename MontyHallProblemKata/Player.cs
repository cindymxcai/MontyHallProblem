using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
    public  class Player
    {
        public bool IsSwitching { get; }
        public int SwitchingChances { get; }

        public Player(bool isSwitching)
        { 
            IsSwitching = isSwitching;
        }
        public Player(IRng isSwitching)
        { 
            SwitchingChances = isSwitching.Next(0,1);
        }
        
        public void ChooseRandomDoor(IRng rng, List<Door> doors)
        {
            var choice = rng.Next(0, 3);
            doors[choice].IsChosen = true;
        }

        public void SwitchDoor(List<Door> doors, bool willPlayerSwitch)
        {
            if (!willPlayerSwitch) return;
            var doorToSwitchTo = doors.FirstOrDefault(x => !x.IsOpened && !x.IsChosen);
            var chosenDoor = doors.FirstOrDefault(x => x.IsChosen);
            if (chosenDoor != null) chosenDoor.IsChosen = false;
            if (doorToSwitchTo != null) doorToSwitchTo.IsChosen = true;
        }
    }
}