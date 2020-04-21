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
            List<Door> doors = new List<Door>{new Door(), new Door(), new Door()};
            Assert.Equal(false, doors[0].IsPrize);
            Assert.Equal(false, doors[1].IsPrize);
            Assert.Equal(false, doors[2].IsPrize);
        }

        [Fact]
        public void PlacePrizeShouldPlaceRandomPrize()
        {
            var montyHall = new MontyHall();
            var number1 = new TestRng(1);
            List<Door> doors = new List<Door>{new Door(), new Door(), new Door()};

            doors[number1.Next(0,3)].IsPrize = true;
            Assert.Equal(false, doors[0].IsPrize);
            Assert.Equal(true, doors[1].IsPrize);
            Assert.Equal(false, doors[2].IsPrize);
        }

        [Fact]
        public void PlayGameChoosingPrizeShouldReturnTrue()
        {
            var montyHall = new MontyHall();
            var number1 = new TestRng(1);
            List<Door> doors = new List<Door>{new Door(), new Door(), new Door()};

            var win =  MontyHall.PlayOneGame(number1, false, doors);
            Assert.True(win);
        }

        [Fact]
        public void PlayingMoreThanOneGameWillKeepScore()
        {
            var montyHall = new MontyHall();
            var number1 = new TestRng(0);
            var wins = MontyHall.PlayAllGames(number1, false,3);
            Assert.Equal(3, wins.Item1);
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