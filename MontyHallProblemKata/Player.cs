using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
    public  class Player
    {
        private double SwitchingChances { get; set; }
        public IRng DoorToChoose { get; }

        public Player( IRng doorToChoose, double isSwitching)
        {
            DoorToChoose = doorToChoose;
            SwitchingChances = isSwitching;
        }
        
        public void ChooseRandomDoor(IRng rng,List<Door> doors)
        {
            var choice = rng.Next(0, 3);
            doors[choice].IsChosen = true;
        }

        public void SwitchDoor(  List<Door> doors)
        {
            while (true)
            {
                if (SwitchingChances == 0)
                {
                }
                else if (SwitchingChances == 1)
                {
                    var doorToSwitchTo = doors.FirstOrDefault(x => !x.IsOpened && !x.IsChosen);
                    var chosenDoor = doors.FirstOrDefault(x => x.IsChosen);
                    if (chosenDoor != null) chosenDoor.IsChosen = false;
                    if (doorToSwitchTo != null) doorToSwitchTo.IsChosen = true;
                }
                else
                {
                    var rng = new Rng();
                    var chance = rng.Next(0, 2);
                    SwitchingChances = chance;
                    continue;
                }

                break;
            }
        }
    }
}