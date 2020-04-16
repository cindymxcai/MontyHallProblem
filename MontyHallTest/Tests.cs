using System;
using System.Collections.Generic;
using MontyHallKata;
using Xunit;

namespace MontyHallTest
{
    public class Tests
    {
        [Fact]
        public void SetUpDoorsShouldInitiallyHaveAllGoats()
        {
            var montyHall = new MontyHall();
            var choice = new Choice();
            var doors = montyHall.SetUpDoors();
            Assert.Equal(false, doors[0].IsPrize);
            Assert.Equal(false, doors[1].IsPrize);
            Assert.Equal(false, doors[2].IsPrize);
        }

        [Fact]
        public void PlacePrizeShouldPlaceRandomPrize()
        {
            var montyHall = new MontyHall();
            var choice = new Choice();
            var doors = montyHall.SetUpDoors();
            var number1 = new TestRng(1);
            montyHall.PlacePrize(number1, doors);
            Assert.Equal(false, doors[0].IsPrize);
            Assert.Equal(true, doors[1].IsPrize);
            Assert.Equal(false, doors[2].IsPrize);
        }
        
    }

    public class TestRng : IRng
    {
        private readonly int _rngNumber;

        public TestRng(int rngNumber)
        {
            _rngNumber = rngNumber;
        }
        public int Next(int minValue, int maxValue)
        {
            return _rngNumber;
        }
    }
}