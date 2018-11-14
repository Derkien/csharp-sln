using UtilityLibraries;

namespace GB1Lesson2
{
    internal partial class Program
    {
        private static TaskReturnCode ExecuteTask2Solution()
        {
            //2.Написать метод подсчета количества цифр числа.

            double Number = ConsoleHelper.ReadInputUntillCorrect("Enter any number", ConsoleHelper.ReadAnyNumberInput);
            string NumberAsString = Number.ToString();

            int DigitsTotal = NumberAsString.Length;
            int DigitsAfterComma = 0;
            int DigitsBeforeComma = 0;
            double ModNumbers = (Number % 1);

            if (ModNumbers != 0)
            {
                DigitsTotal--;

                string ModNumbersString = string.Format("{0:N2}", ModNumbers);
                DigitsAfterComma = ModNumbersString.Substring(2).Length;
                DigitsBeforeComma = DigitsTotal - DigitsAfterComma;
            }

            ConsoleHelper.PrintAndPause(
                $"Number {Number} consists of total {DigitsTotal} digits"
                + (DigitsAfterComma > 0 ? $": {DigitsBeforeComma} before comma, {DigitsAfterComma} after comma" : "")
            );


            return TaskReturnCode.Continue;
        }
    }
}
