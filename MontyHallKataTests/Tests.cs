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
            var doorNumber = new TestRng(1);
            montyHall.SetUpThreeDoors(doorNumber);
            var choice = new TestRng(2);
            var player = new Player(1);
            player.ChooseRandomDoor(choice, montyHall.Doors);
            Assert.Equal(false, montyHall.Doors[0].IsChosen);
            Assert.Equal(false, montyHall.Doors[1].IsChosen);
            Assert.Equal(true, montyHall.Doors[2].IsChosen);
        }

        [Fact]
        public void HostShouldOpenAnUnSelectedDoorThatIsGoat()
        {
            var montyHall = new MontyHall();
            var host = new Host();
            var doorNumber = new TestRng(1);
            montyHall.SetUpThreeDoors(doorNumber);
            var choice = new TestRng(2);
            var player = new Player(1);
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
            var host = new Host();
            var doorNumber = new TestRng(1);
            montyHall.SetUpThreeDoors(doorNumber);
            var choice = new TestRng(2);
            var player = new Player(1);
            player.ChooseRandomDoor(choice, montyHall.Doors);
            host.OpenUnselectedDoorThatIsGoat(montyHall.Doors);
            player.SwitchDoor(montyHall.Doors, player.SwitchingChances);
            Assert.Equal(false, montyHall.Doors[0].IsChosen);
            Assert.Equal(true, montyHall.Doors[1].IsChosen);
            Assert.Equal(false, montyHall.Doors[2].IsChosen);
        }

        [Fact]
        public void PlayGameShouldReturnTrueIfChosenDoorIsPrize()
        {
            var montyHall = new MontyHall();
            var car = new TestRng(2);
            var choice = new TestRng(0);
            Assert.Equal(Prize.Car, montyHall.PlayGame(car, choice, 1));
        }

        [Theory]
        [InlineData(2, 0, 1000)]
        [InlineData(2, 2, 0)]
        public void SimulateGamePlayGivenNumberOfTimesRecordsWinsAndLosses(int prizeNumber, int choiceNumber,
            int expected)
        {
            var prize = new TestRng(prizeNumber);
            var choice = new TestRng(choiceNumber);
            var simulator = new Simulator();
            simulator.PlayAllGames(prize, choice, 1);
            Assert.Equal(expected, simulator.PlayAllGames(prize, choice, 1).Item1);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void SimulatorShouldDetermineIfPlayerSwitches(bool expected, int willPlayerSwitch)
        {
            var prize = new TestRng(2);
            var choice = new TestRng(0);
            var simulator = new Simulator();
            simulator.PlayAllGames(prize, choice, willPlayerSwitch);
            var montyHall = new MontyHall();
            montyHall.PlayGame(prize, choice, willPlayerSwitch);
            Assert.Equal(expected, montyHall.Doors[0].IsChosen);
        }

        [Theory]
        [InlineData(2, 0)]

        public void SimulatorShouldPlayGameWherePlayerSwitchesRandomly(int prizeDoor, int chosenDoor)
        {
            var prize = new TestRng(prizeDoor);
            var choice = new TestRng(chosenDoor);
            var simulator = new Simulator();
            Assert.Equal(1000 ,simulator.PlayAllGames(prize,choice, 1).Item1);
            Assert.Equal(0, simulator.PlayAllGames(prize, choice, 0).Item1);
        }
    }

    public class TestRng : IRng
    {
        private readonly int _numberToReturn;

        public TestRng(int numberToReturn)
        {
            _numberToReturn = numberToReturn;
        }

        public int Next(int minValue, int maxValue)
        {
            return _numberToReturn;
        }
    }
}