using System;

namespace GB1Lesson7
{
    internal class NumberGuesser
    {
        private const string ResultWon = "You won!";
        private const string ResultLess = "Your number is less!";
        private const string ResultHigher = "Your number is higher!";
        private const string ResultInvalid = "Invalid number provided!";

        public NumberGuesser()
        {
            TryCount = 0;
            ExpectedResult = GetNewRandomNumber();
        }

        private int GetNewRandomNumber()
        {
            return (new Random()).Next(1, 100);
        }

        public void RestartGame()
        {
            TryCount = 0;
            ExpectedResult = GetNewRandomNumber();
        }

        public string GetCheckUserInputResult(string UserInput)
        {
            TryCount++;

            if (int.TryParse(UserInput, out int CurrentNumber))
            {
                if (CurrentNumber == ExpectedResult)
                {
                    return string.Format($"{ResultWon} The number is {ExpectedResult}!");
                }

                return CurrentNumber > ExpectedResult ? ResultHigher : ResultLess;
            }

            return ResultInvalid;
        }

        public int TryCount { get; private set; }
        public int ExpectedResult { get; private set; }
    }
}
