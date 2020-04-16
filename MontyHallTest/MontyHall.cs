using System.Collections.Generic;

namespace MontyHallTest
{
    public class MontyHall
    {
        public List<Choice> SetUpDoors()
        {
            List<Choice> choices = new List<Choice>{new Choice(), new Choice(), new Choice()};
            return choices;
        }
    }

    public class Choice
    {
        public bool IsPrize = false;
        public bool IsSelected = false;
    }
}