using MontyHallProblemKata;
using Xunit;

namespace MontyHallKataTests
{
    public class Tests
    {
        [Fact]
        public void CreateThreeDoorsAssignsPrizeToRandomDoor()
        {
            var montyHall = new MontyHall();
            var doorNumber = new TestRng(1);
            montyHall.SetUpThreeDoors(doorNumber);
            Assert.Equal(false, montyHall.Doors[0].Prize == Prize.Car);
            Assert.Equal(true, montyHall.Doors[1].Prize == Prize.Car);
            Assert.Equal(false, montyHall.Doors[2].Prize == Prize.Car);
        }

        [Fact]
        public void PlayerShouldBeAbleToChooseARandomDoor()
        {
            var montyHall = new MontyHall();
            var player = new Player();
            var doorNumber = new TestRng(1);
            montyHall.SetUpThreeDoors(doorNumber);
            var choice = new TestRng(2);
            player.ChooseRandomDoor(choice, montyHall.Doors);
            Assert.Equal(false, montyHall.Doors[0].IsChosen);
            Assert.Equal(false, montyHall.Doors[1].IsChosen);
            Assert.Equal(true, montyHall.Doors[2].IsChosen);
        }

        [Fact]
        public void HostShouldOpenAnUnSelectedDoorThatIsGoat()
        {
            var montyHall = new MontyHall();
            var player = new Player();
            var host = new Host();
            
            var doorNumber = new TestRng(1);
            montyHall.SetUpThreeDoors(doorNumber);
            var choice = new TestRng(2);
            player.ChooseRandomDoor(choice, montyHall.Doors);
            host.OpenUnselectedDoorThatIsGoat(montyHall.Doors);
            
            Assert.Equal(true, montyHall.Doors[0].IsOpened);
            Assert.Equal(false, montyHall.Doors[1].IsOpened);
            Assert.Equal(false, montyHall.Doors[2].IsOpened);
        }

        [Fact]
        public void PlayerShouldBeAbleToASwitchDoors()
        {
            var montyHall = new MontyHall();
            var player = new Player();
            var host = new Host();
            
            var doorNumber = new TestRng(1);
            montyHall.SetUpThreeDoors(doorNumber);
            var choice = new TestRng(2);
            player.ChooseRandomDoor(choice, montyHall.Doors);
            host.OpenUnselectedDoorThatIsGoat(montyHall.Doors);

            player.SwitchDoor(montyHall.Doors, true);
            
            Assert.Equal(false, montyHall.Doors[0].IsChosen);
            Assert.Equal(true, montyHall.Doors[1].IsChosen);
            Assert.Equal(false, montyHall.Doors[2].IsChosen);
        }

        [Fact]
        public void PlayGameShouldReturnTrueIfChosenDoorIsPrize()
        {
            var montyHall  = new MontyHall();
            var car = new TestRng(2);
            var choice = new TestRng(0);
            Assert.Equal(Prize.Car,montyHall.PlayGame(car, choice, true));
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
            var montyHall = new MontyHall();
            montyHall.PlayGame(prize, choice, true);
            Assert.False(montyHall.Doors[0].IsChosen);

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