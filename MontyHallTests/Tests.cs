
using System.Linq;
using MontyHallProblem;
using Xunit;

namespace MontyHallTests
{
    public class Tests
    {
        [Fact]
        public void GameShouldSetUpDoorsWithNoPrize()
        {
            var montyHall = new MontyHall();
            Assert.False(montyHall.Doors[0].IsPrize);
            Assert.False(montyHall.Doors[1].IsPrize);
            Assert.False(montyHall.Doors[2].IsPrize);
        }

        [Fact]
        public void StartingNewGameShouldPlaceAPrizeBehindRandomDoor()
        {
            var montyHall = new MontyHall();
            montyHall.PlayGame(true);
            Assert.True(montyHall.Doors.Any(x => x.IsPrize));
        }

        [Fact]
        public void PlayerShouldSelectRandomDoor()
        {
            var montyHall = new MontyHall();
            montyHall.PlayGame(true);
            Assert.True(montyHall.Doors.Any(x => x.IsSelected));
        }

        [Fact]
        public void HostShouldDisplayRemainingDoorNotContainingPrize()
        {
            var montyHall = new MontyHall();
            var host = new Host();
            var displayedDoor = host.DisplayRemainingDoorContainingNoPrize(montyHall.Doors);
            Assert.False(displayedDoor.IsPrize && displayedDoor.IsSelected);
        }

        [Fact]
        public void PlayerShouldBeAbleToSwitchSelectedDoor()
        {
            var montyHall = new MontyHall();
            montyHall.PlayGame(true);
            //assert if switched 
        }
    }
}