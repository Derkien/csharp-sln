using System;
using UtilityLibraries;

namespace GB1Lesson2
{
    internal partial class Program
    {
        private static TaskReturnCode ExecuteTask6Solution()
        {
            //6. * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
            //«Хорошим» называется число, которое делится на сумму своих цифр.
            //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

            Console.WriteLine("Start searching good numbers... please wait");
            int RangeStart = 1;
            int RangeEnd = 1000000000;

            // для наших целей лучше использовать Stopwatch
            var StopWatch = System.Diagnostics.Stopwatch.StartNew();
            int TotalGoodNumbers = GetGoodNumbersFromRange(RangeStart, RangeEnd);
            StopWatch.Stop();
            TimeSpan TimeSpan = StopWatch.Elapsed;

            ConsoleHelper.PrintAndPause($"Total Good numbers in range[{RangeStart},{RangeEnd}]: {TotalGoodNumbers}; Execution time: {TimeSpan.Minutes}m {TimeSpan.Seconds}s {TimeSpan.Milliseconds}ms");

            return TaskReturnCode.Continue;
        }

        private static int GetGoodNumbersFromRange(int RangeStart, int RangeEnd)
        {
            int TotalGoodNumbers = 0;

            foreach (int nextInteger in IntegersSequence(RangeStart, RangeEnd))
            {
                if (nextInteger % GetSumOfNumberDigits(nextInteger) == 0)
                {
                    TotalGoodNumbers++;
                }
            }

            return TotalGoodNumbers;
        }

        private static System.Collections.Generic.IEnumerable<int> IntegersSequence(int RangeStart, int RangeEnd)
        {
            while (RangeStart <= RangeEnd)
            {
                yield return RangeStart++;
            }
        }

        private static int GetSumOfNumberDigits(int number)
        {
            int sum = 0;
            int r;
            while (number != 0)
            {
                r = number % 10;
                number /= 10;
                sum += r;
            }

            return sum;
        }

    }
}
