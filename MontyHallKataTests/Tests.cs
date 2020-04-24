﻿using MontyHallProblemKata;
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
            var montyHall = new MontyHall();
            var car = new TestRng(2);
            var choice = new TestRng(0);
            Assert.Equal(Prize.Car, montyHall.PlayGame(car, choice, true));
        }

        [Theory]
        [InlineData(2, 0, 1000)]
        [InlineData(2, 2, 0)]
        public void SimulateGamePlayGivenNumberOfTimesRecordsWinsAndLosses(int prizeNumber, int choiceNumber,
            int expected)
        {
            var prize = new TestRng(prizeNumber);
            var choice = new TestRng(choiceNumber);
            Simulator.PlayAllGames(prize, choice, true);
            Assert.Equal(expected, Simulator.PlayAllGames(prize, choice, true).Item1);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void SimulatorShouldDetermineIfPlayerSwitches(bool expected, bool willPlayerSwitch)
        {
            var prize = new TestRng(2);
            var choice = new TestRng(0);
            Simulator.PlayAllGames(prize, choice, willPlayerSwitch);
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
            var switches = new TestRng(0);
            var stays = new TestRng(1);
            Assert.Equal(1000 ,Simulator.PlayAllGames(prize,choice, switches).Item1);
            Assert.Equal(0, Simulator.PlayAllGames(prize, choice, stays).Item1);
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