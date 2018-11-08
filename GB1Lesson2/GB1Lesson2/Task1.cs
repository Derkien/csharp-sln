using UtilityLibraries;

namespace GB1Lesson2
{
    internal partial class Program
    {
        private static TaskReturnCode ExecuteTask1Solution()
        {
            // 1. Написать метод, возвращающий минимальное из трёх чисел.

            double NumberA = ConsoleHelper.ReadInputUntillCorrect("Enter number A", ConsoleHelper.ReadAnyNumberInput);
            double NumberB = ConsoleHelper.ReadInputUntillCorrect("Enter number B", ConsoleHelper.ReadAnyNumberInput);
            double NumberC = ConsoleHelper.ReadInputUntillCorrect("Enter number B", ConsoleHelper.ReadAnyNumberInput);

            double MinimumValue = GetMinimumOfTwoNumbers(GetMinimumOfTwoNumbers(NumberA, NumberB), NumberC);

            ConsoleHelper.PrintAndPause($"Minimun of A:{NumberA}, B:{NumberB} and C:{NumberC} is number: {MinimumValue}");

            return TaskReturnCode.Continue;
        }

        private static double GetMinimumOfTwoNumbers(double numberA, double numberB)
        {
            return numberA < numberB ? numberA : numberB;
        }
    }
}
