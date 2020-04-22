
using System.Linq;

namespace MontyHallProblemKata
{
   public class MontyHall
   {
      public  bool PlayGame(IRng prize, IRng choice, bool willPlayerSwitch)
      {
         var door = new Door();
         var doors = door.SetUpThreeDoors();
         door.PlacePrize(prize,doors);
         
         var player = new Player();
         player.ChooseRandomDoor(choice, doors);
         
         var host = new Host();
         host.OpenUnselectedDoorThatIsntPrize(doors);
         
         player.SwitchDoor(doors, willPlayerSwitch);

         return doors.First(x => x.IsChosen).IsPrize;
      }
   }
}