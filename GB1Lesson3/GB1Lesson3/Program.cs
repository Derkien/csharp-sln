using System;
using UtilityLibraries;

namespace GB1Lesson3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // * Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
            //   Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
            //   Написать программу, демонстрирующую все разработанные элементы класса.
            // * Добавить свойства типа int для доступа к числителю и знаменателю;
            // * Добавить проверку на ввод данных с помощью TryParse;
            // * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            // ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
            // *** Добавить упрощение дробей.
            ConsoleHelper.PrintAndPause("Hello! Provide data for make FractionA: A/B, e.g. 3/4", ConsoleColor.DarkCyan);

            int NumberA = ConsoleHelper.ReadInputUntillCorrect("Enter number A", ConsoleHelper.ReadAnyInteger);
            int NumberB = ConsoleHelper.ReadInputUntillCorrect("Enter number B", ConsoleHelper.ReadAnyInteger);

            Fraction FractionA = new Fraction(NumberA, NumberB);

            ConsoleHelper.PrintAndPause($"Ok. First FractionA {NumberA}/{NumberB} is simplified and its: {FractionA}", ConsoleColor.Magenta);

            ConsoleHelper.PrintAndPause("Now Provide data for make FractionE: C/D, e.g. 3/4", ConsoleColor.DarkCyan);

            int NumberC = ConsoleHelper.ReadInputUntillCorrect("Enter number C", ConsoleHelper.ReadAnyInteger);
            int NumberD = ConsoleHelper.ReadInputUntillCorrect("Enter number D", ConsoleHelper.ReadAnyInteger);

            Fraction FractionE = new Fraction(NumberC, NumberD);

            ConsoleHelper.PrintAndPause($"Ok. Second FractionA {NumberC}/{NumberD} is simplified and its: {FractionE}", ConsoleColor.Magenta);

            ConsoleHelper.PrintConsoleMessageWithColor("Math operations with FractionA and FractionE:", ConsoleColor.Cyan);
            Console.WriteLine("FractionA + FractionE: {0} + {1} = {2}", FractionA, FractionE, (FractionA + FractionE));
            Console.WriteLine("FractionA - FractionE: {0} - {1} = {2}", FractionA, FractionE, (FractionA - FractionE));
            Console.WriteLine("FractionA * FractionE: {0} * {1} = {2}", FractionA, FractionE, (FractionA * FractionE));
            Console.WriteLine("FractionA / FractionE: {0} / {1} = {2}", FractionA, FractionE, (FractionA / FractionE));

            ConsoleHelper.PrintConsoleMessageWithColor("Now the same but with method usage:", ConsoleColor.Cyan);
            Console.WriteLine("FractionA.Sum(FractionE): {0} + {1} = {2}", FractionA, FractionE, FractionA.Sum(FractionE));
            Console.WriteLine("FractionA.Sub(FractionE): {0} - {1} = {2}", FractionA, FractionE, FractionA.Sub(FractionE));
            Console.WriteLine("FractionA.Mult(FractionE): {0} * {1} = {2}", FractionA, FractionE, FractionA.Mult(FractionE));
            Console.WriteLine("FractionA.Div(FractionE): {0} / {1} = {2}", FractionA, FractionE, FractionA.Div(FractionE));

            ConsoleHelper.PrintConsoleMessageWithColor("Fractions to double:", ConsoleColor.Cyan);
            Console.WriteLine("FractionA: {0} = {1}", FractionA, FractionA.Double);
            Console.WriteLine("FractionE: {0} = {1}", FractionE, FractionE.Double);

            ConsoleHelper.PrintConsoleMessageWithColor("Get numerator and denominator with getter methods:", ConsoleColor.Cyan);
            Console.WriteLine("FractionA.Numerator / FractionA.Denominator: {0} / {1}", FractionA.Numerator, FractionA.Denominator);
            Console.WriteLine("FractionE.Numerator / FractionE.Denominator: {0} / {1}", FractionE.Numerator, FractionE.Denominator);

            Console.ReadKey();
        }
    }
}
