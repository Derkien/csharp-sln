using UtilityLibraries;

namespace GB1Lesson2
{
    internal partial class Program
    {
        private static TaskReturnCode ExecuteTask3Solution()
        {
            //3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечётных положительных чисел.

            double SumOfPositiveEvenNumbers = 0;
            double InputNumber = 0;
            do
            {
                InputNumber = ConsoleHelper.ReadInputUntillCorrect("Input any integer. Print 0 to stop input.", ConsoleHelper.ReadAnyInteger);
                if (InputNumber > 0 && InputNumber % 2 != 0)
                {
                    SumOfPositiveEvenNumbers += InputNumber;
                }
            } while (InputNumber != 0);

            ConsoleHelper.PrintAndPause($"Summ of even positive numbers: {SumOfPositiveEvenNumbers}");

            return TaskReturnCode.Continue;
        }
    }
}
