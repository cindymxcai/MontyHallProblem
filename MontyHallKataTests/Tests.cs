using MontyHallProblemKata;
using Xunit;

namespace MontyHallKataTests
{
    public class Tests
    {
        [Theory]
        [InlineData(false, 0)]
        [InlineData(false, 1)]
        [InlineData(false, 2)]
        public void CreateThreeDoors(bool expected, int doorNumber)
        {
            var door = new Door();
            var doors = door.SetUpThreeDoors();
            Assert.Equal(expected, doors[doorNumber].IsChosen);
            Assert.Equal(expected, doors[doorNumber].IsDisplayed);
            Assert.Equal(expected, doors[doorNumber].IsPrize);
        }

        [Fact]
        public void AssignPrizeToARandomDoor()
        {
            var door = new Door();
            var doorNumber = new TestRng(1);
            var doors = door.SetUpThreeDoors();
            door.PlacePrize(doorNumber, doors);
            Assert.Equal(false, door.Doors[0].IsPrize);
            Assert.Equal(true, door.Doors[1].IsPrize);
            Assert.Equal(false, door.Doors[2].IsPrize);
        }

        [Fact]
        public void PlayerShouldBeAbleToChooseARandomDoor()
        {
            var door = new Door();
            var player = new Player();
            var doors = door.SetUpThreeDoors();
            var choice = new TestRng(2);
            player.ChooseRandomDoor(choice, doors);
            Assert.Equal(false, door.Doors[0].IsChosen);
            Assert.Equal(false, door.Doors[1].IsChosen);
            Assert.Equal(true, door.Doors[2].IsChosen);
        }
    }

    public class TestRng : IRng
    {
        private readonly int _doorNumberToReturn;

        public TestRng(int doorNumberToReturn)
        {
            _doorNumberToReturn = doorNumberToReturn;
        }

        public int Next(int minValue, int maxValue)
        {
            return _doorNumberToReturn;
        }
    }
}