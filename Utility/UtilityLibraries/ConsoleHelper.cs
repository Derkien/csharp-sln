using System;
using System.Collections.Generic;
using System.Globalization;

namespace UtilityLibraries
{
    public static class ConsoleHelper
    {
        public static void ReadAndAssignInput(string message, ref string value)
        {
            value = ReadAnyNonEmptyString(message);
        }

        public static string ReadAnyNonEmptyString(string message)
        {
            Console.WriteLine(message);
            string InputValue = Console.ReadLine();
            if (string.IsNullOrEmpty(InputValue))
            {
                throw new Exception("Any string expected");
            }

            return InputValue;
        }

        public static void ReadAndAssignInput(string message, ref uint value)
        {
            value = ReadAnyPositiveInteger(message);
        }

        public static uint ReadAnyPositiveInteger(string message)
        {
            Console.WriteLine(message);
            bool ParseIsSuccess = uint.TryParse(Console.ReadLine(), out uint InputValue);
            if (!ParseIsSuccess || InputValue <= 0)
            {
                throw new Exception("Any positive integer expected");
            }

            return InputValue;
        }

        public static int ReadAnyInteger(string message)
        {
            Console.WriteLine(message);
            bool ParseIsSuccess = int.TryParse(Console.ReadLine(), out int InputValue);
            if (!ParseIsSuccess)
            {
                throw new Exception("Any positive integer expected");
            }

            return InputValue;
        }

        public static void ReadAndAssignInput(string message, ref double value)
        {
            value = ReadAnyPositiveNumber(message);
        }

        public static double ReadAnyPositiveNumber(string message)
        {
            Console.WriteLine(message);
            bool ParseIsSuccess = double.TryParse(Console.ReadLine().Replace(".", ","), NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("ru-RU"), out double InputValue);
            if (!ParseIsSuccess || InputValue <= 0)
            {
                throw new Exception("Any positive number expected");
            }

            return InputValue;
        }

        public static void ReadAndAssignInput(string message, ref double? value)
        {
            value = ReadAnyNumberInput(message);
        }

        public static double ReadAnyNumberInput(string message)
        {
            Console.WriteLine(message);
            bool ParseIsSuccess = double.TryParse(Console.ReadLine().Replace(".", ","), NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("ru-RU"), out double InputValue);
            if (!ParseIsSuccess)
            {
                throw new Exception("Any number expected");
            }

            return InputValue;
        }

        public static void PrintConsoleMessageAtTheMiddle(string title, string outputString)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Format("{0, " + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(string.Format("{0, " + ((Console.WindowWidth / 2) + (outputString.Length / 2)) + "}", outputString));
            Console.ResetColor();
        }

        public static void PrintConsoleMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintMenu(IReadOnlyDictionary<uint, string> menuItems)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Program menu:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var MenuItem in menuItems)
            {
                Console.WriteLine("{0} - {1}", MenuItem.Key, MenuItem.Value);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Choose one and press Enter...");
            Console.ResetColor();
        }

        public static uint PrintMenuAndReadChoice(IReadOnlyDictionary<uint, string> menuItems)
        {
            bool ParseInputResult = false;
            uint UserChoice;
            do
            {
                PrintMenu(menuItems);
                ParseInputResult = uint.TryParse(Console.ReadLine(), out UserChoice);
                if (!ParseInputResult)
                {
                    Console.WriteLine("Invalid choise. Press any key...");
                    Console.ReadKey();
                }
            } while (!ParseInputResult);

            return UserChoice;
        }

        public static T ReadInputUntillCorrect<T>(string message, Func<string, T> func)
        {
            try
            {
                return func(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return ReadInputUntillCorrect(message, func);
        }

        public static double ReadAnyNumberInputUntillCorrect(string message)
        {
            try
            {
                return ReadAnyNumberInput(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return ReadAnyNumberInputUntillCorrect(message);
        }

        public static void PrintAndPause(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key for continue...");
            Console.ReadKey();
        }

        public static void ClearPreviousNLines(int numberOfLinesToClear)
        {
            for (int i = 0; i < numberOfLinesToClear; i++)
            {
                int CursorPreviousLine = Console.CursorTop - 1;
                Console.SetCursorPosition(0, CursorPreviousLine);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, CursorPreviousLine);
            }
        }
    }
}
