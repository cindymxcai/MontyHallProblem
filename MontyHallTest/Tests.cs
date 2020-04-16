using System;
using System.Collections.Generic;
using Xunit;

namespace MontyHallTest
{
    public class Tests
    {
        [Fact]
        public void SetUpDoorsShouldAllInitiallyHaveGoats()
        {
            var montyHall = new MontyHall();
            var choice = new Choice();
            var doors = montyHall.SetUpDoors();
            Assert.Equal(false, doors[0].IsPrize);
            Assert.Equal(false, doors[1].IsPrize);
            Assert.Equal(false, doors[2].IsPrize);
        }
    }
}