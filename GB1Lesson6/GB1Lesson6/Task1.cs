using System;
using UtilityLibraries;

namespace GB1Lesson6
{
    /// <summary>
    /// 1. Изменить программу вывода таблицы функции (метод void Table(Fun F, double x, double b), так чтобы можно было передавать функции типа double (double, double). 
    /// а) Продемонстрировать работу на функции с функцией a* x^2 и функцией a* sin(x);
    /// б) Выполнить задание а с использованием лямбда-выражений.
    /// </summary>
    internal partial class Program
    {
        public delegate double Func(double a, double b);

        private static TaskReturnCode ExecuteTask1Solution()
        {
            ConsoleHelper.PrintAndPause("Вывести результат работы a*x^2");
            Table(FunctionOne, 4, 6);
            ConsoleHelper.PrintAndPause("Вывести результат работы a*sin(x) через лямбда функцию");
            Table((a, x) => a * Math.Sin(Math.PI * x / 180.0), 30, 60, 15);
            ConsoleHelper.PrintAndPause("Конец программы");

            return TaskReturnCode.Continue;
        }

        public static void Table(Func func, double x, double a, int step = 1)
        {
            Console.WriteLine(" ----- X ----- ----- A ----- --- Func --- ");
            while (x <= a)
            {
                Console.WriteLine("| {0,11:0.000} | {1,11:0.000} | {2,10:0.000} |", x, a, func(a, x));
                x += step;
            }
            Console.WriteLine(" ---------------------------------------- ");
        }

        private static double FunctionOne(double a, double x)
        {
            return a * Math.Pow(x, 2);
        }
    }
}
