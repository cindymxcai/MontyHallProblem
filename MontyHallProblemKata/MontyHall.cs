
using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
   public class MontyHall
   {
      public List<Door> Doors { get; private set; }
      public  Prize PlayGame(IRng doorToPlaceCar, IRng doorToChoose, bool willPlayerSwitch)
      {
         SetUpThreeDoors(doorToPlaceCar);
         
         var player = new Player();
         player.ChooseRandomDoor(doorToChoose, Doors);
         
         var host = new Host();
         host.OpenUnselectedDoorThatIsGoat(Doors);
         
         player.SwitchDoor(Doors, willPlayerSwitch);

         return Doors.First(x => x.IsChosen).Prize;
      }

      public void SetUpThreeDoors(IRng rng)
      {
          Doors = new List<Door> {new Door(), new Door(), new Door()}; 
          var door = rng.Next(0, 3);
          Doors[door].Prize = Prize.Car;
      }

      
   }
}