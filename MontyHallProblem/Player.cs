using System.Collections.Generic;
using System.Linq;
using MontyHallTests;

namespace MontyHallProblem
{
    public class Player
    {
        public bool IsPlayerSwitching { get; }
        private readonly Rng _rng = new Rng();
        public Door ChosenDoor;

        public Player(bool isPlayerSwitching)
        {
            IsPlayerSwitching = isPlayerSwitching;
        }
        public void SelectRandomDoor(List<Door> doors)
        {
            var selection = _rng.Next(0, 3);
             ChosenDoor = doors[selection];
             ChosenDoor.IsSelected = true;
        }

        public void SwitchDoor(IEnumerable<Door> doors)
        {
            ChosenDoor = doors.FirstOrDefault(x => !x.IsSelected);
            ChosenDoor.IsSelected = true;
        }
    }
}