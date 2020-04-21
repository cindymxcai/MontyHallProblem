using System;
using Xunit;

namespace MontyHallTests
{
    public class Tests
    {
        [Fact]
        public void GameShouldSetUpDoorsWithNoPrize()
        {
            var montyHall = new MontyHall();
            Assert.False(montyHall.Doors[0].isPrize);
            Assert.False(montyHall.Doors[1].isPrize);
            Assert.False(montyHall.Doors[2].isPrize);

        }
    }
}