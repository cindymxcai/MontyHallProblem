using System;
using System.Linq;
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
            montyHall.PlayGame();
            Assert.True(montyHall.Doors.Any(x => x.IsPrize == true));
        }
    }
}