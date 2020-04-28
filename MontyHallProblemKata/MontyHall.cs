
using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblemKata
{
   public class MontyHall
   {
      public List<Door> Doors { get; private set; }
      public  Prize PlayGame(IRng doorToPlaceCar, Player player)
      {
         SetUpThreeDoors(doorToPlaceCar);
         
         player.ChooseRandomDoor (player.DoorToChoose, Doors);
         var host = new Host();
         host.OpenUnselectedDoorThatIsGoat(Doors);
         
         player.SwitchDoor(Doors); 

         return Doors.First(x => x.IsChosen).Prize;
      }

      public void SetUpThreeDoors(IRng rng)
      {
          Doors = new List<Door> {new Door(), new Door(), new Door()}; 
          Doors[rng.Next(0,3)].Prize = Prize.Car;
      }

      
   }
}