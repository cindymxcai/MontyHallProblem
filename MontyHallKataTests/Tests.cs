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
            Assert.Equal(expected, doors[doorNumber].IsOpened);
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

        [Fact]
        public void HostShouldOpenAnUnSelectedDoorThatIsntPrize()
        {
            var door = new Door();
            var player = new Player();
            var host = new Host();
            
            var doors = door.SetUpThreeDoors();
            var choice = new TestRng(2);
            var prize = new TestRng(0);
            door.PlacePrize(prize, doors);
            player.ChooseRandomDoor(choice, doors);
            host.OpenUnselectedDoorThatIsntPrize(doors);
            
            Assert.Equal(false, door.Doors[0].IsOpened);
            Assert.Equal(true, door.Doors[1].IsOpened);
            Assert.Equal(false, door.Doors[2].IsOpened);
        }

        [Fact]
        public void PlayerShouldBeAbleToASwitchDoors()
        {
            var door = new Door();
            var player = new Player();
            var host = new Host();
            
            var doors = door.SetUpThreeDoors();
            var choice = new TestRng(2);
            var prize = new TestRng(0);
            door.PlacePrize(prize, doors);
            player.ChooseRandomDoor(choice, doors);
            host.OpenUnselectedDoorThatIsntPrize(doors);

            player.SwitchDoor(doors, true);
            
            Assert.Equal(true, door.Doors[0].IsChosen);
            Assert.Equal(false, door.Doors[1].IsChosen);
            Assert.Equal(false, door.Doors[2].IsChosen);
        }

        [Fact]
        public void PlayGameShouldReturnTrueIfChosenDoorIsPrize()
        {
            var montyHall  = new MontyHall();
            var prize = new TestRng(2);
            var choice = new TestRng(0);
            Assert.True(montyHall.PlayGame(prize, choice, true));
        }

        [Theory]
        [InlineData(2, 0, 1000)]
        [InlineData(2, 2, 0)]
        public void SimulateGamePlayGivenNumberOfTimesRecordsWinsAndLosses(int prizeNumber, int choiceNumber, int expected)
        {
            var simulator = new Simulator();
            var prize = new TestRng(prizeNumber);
            var choice = new TestRng(choiceNumber);
            simulator.PlayAllGames(prize, choice, true);
            Assert.Equal(expected, simulator.PlayAllGames(prize, choice, true).Item1);
        }

        [Fact]
        public void SimulatorShouldDetermineIfPlayerSwitches()
        {
            var simulator = new Simulator();
            var prize = new TestRng(2);
            var choice = new TestRng(0);
            simulator.PlayAllGames(prize, choice, true);
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