using System;
using UtilityLibraries;

namespace GB1Lesson2
{
    internal partial class Program
    {
        private static TaskReturnCode ExecuteTask7Solution()
        {
            //7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a < b).
            //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
            uint NumberA, NumberB;
            int StartProgramCursorPosition = Console.CursorTop;
            do
            {
                var Numbers = ReadInputNumbers();
                NumberA = Numbers.Item1;
                NumberB = Numbers.Item2;
                if (NumberA > NumberB)
                {
                    ConsoleHelper.PrintAndPause("B must be less than A!");
                    ConsoleHelper.ClearPreviousNLines(Console.CursorTop - StartProgramCursorPosition);
                }
            } while (NumberA > NumberB);

            PrintIntegersFromRange(NumberA, NumberB);
            PrintSumOfIntegersFromRange(NumberA, NumberB);
            ConsoleHelper.PrintAndPause("");

            return TaskReturnCode.Continue;
        }

        private static Tuple<uint, uint> ReadInputNumbers()
        {
            uint NumberA = ConsoleHelper.ReadInputUntillCorrect("Enter number A:", ConsoleHelper.ReadAnyPositiveInteger);
            uint NumberB = ConsoleHelper.ReadInputUntillCorrect("Enter number B (note: B > A):", ConsoleHelper.ReadAnyPositiveInteger);

            return new Tuple<uint, uint>(NumberA, NumberB);
        }

        private static void PrintIntegersFromRange(uint rangeStart, uint rangeEnd)
        {
            Console.WriteLine($"Sequence of integers in range [{rangeStart},{rangeEnd}]: ");
            PrintNextIntegerFromRange(rangeStart, rangeEnd);
        }

        private static void PrintNextIntegerFromRange(uint rangeStart, uint rangeEnd)
        {
            if (rangeStart <= rangeEnd)
            {
                Console.WriteLine($" {rangeStart}");
                PrintNextIntegerFromRange(++rangeStart, rangeEnd);

                return;
            }
        }

        private static void PrintSumOfIntegersFromRange(uint rangeStart, uint rangeEnd)
        {
            Console.WriteLine($"Sum of integers in range [{rangeStart},{rangeEnd}]: {SumOfIntegersInRange(rangeStart, rangeEnd)}");
        }

        private static uint SumOfIntegersInRange(uint rangeStart, uint rangeEnd)
        {
            uint SumOfIntegers = rangeStart;

            if (rangeStart < rangeEnd)
            {
                SumOfIntegers += SumOfIntegersInRange(++rangeStart, rangeEnd);

                return SumOfIntegers;
            }
            else if (rangeStart == rangeEnd)
            {
                return rangeStart;
            }

            return 0;
        }
    }
}
