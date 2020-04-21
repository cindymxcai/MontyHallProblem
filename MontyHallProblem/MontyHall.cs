using System.Collections.Generic;
using MontyHallTests;

namespace MontyHallProblem
{
    public class MontyHall
    {
        public readonly List<Door> Doors = new List<Door> {new Door(), new Door(), new Door()};
        private readonly Rng _rng = new Rng();

        public bool PlayGame(bool willPlayerSwitch)
        {
            Doors[_rng.Next(0, 3)].IsPrize = true;
            var player = new Player(willPlayerSwitch);
            
            player.SelectRandomDoor(Doors);

            var host = new Host();
            var displayedDoor = host.DisplayRemainingDoorContainingNoPrize(Doors);
            Doors.Remove(displayedDoor);

            if (player.IsPlayerSwitching)
            {
                player.SwitchDoor(Doors); 
            }

            return player.ChosenDoor.IsPrize;
        }
    }

}