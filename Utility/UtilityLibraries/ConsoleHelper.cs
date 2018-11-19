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
            PrintConsoleMessageWithColor(
                string.Format("{0, " + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title),
                ConsoleColor.Blue
            );
            PrintConsoleMessageWithColor(
                string.Format("{0, " + ((Console.WindowWidth / 2) + (outputString.Length / 2)) + "}", outputString),
                ConsoleColor.DarkGreen
            );
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
            PrintConsoleMessageWithColor("Program menu:", ConsoleColor.Yellow);
            foreach (var MenuItem in menuItems)
            {
                PrintConsoleMessageWithColor($"{MenuItem.Key} - {MenuItem.Value}", ConsoleColor.DarkYellow);
            }
            PrintConsoleMessageWithColor("Choose one and press Enter...", ConsoleColor.Cyan);
        }

        public static uint PrintMenuAndReadChoice(IReadOnlyDictionary<uint, string> menuItems)
        {
            bool ParseInputResult = false;
            uint UserChoice;

            PrintMenu(menuItems);

            int StartProgramCursorPosition = Console.CursorTop;
            do
            {
                ParseInputResult = uint.TryParse(Console.ReadLine(), out UserChoice);
                if (!ParseInputResult)
                {
                    PrintAndPause("Invalid choise.");
                    ClearPreviousNLines(Console.CursorTop - StartProgramCursorPosition);
                }
            } while (!ParseInputResult);

            return UserChoice;
        }

        public static T ReadInputUntillCorrect<T>(string message, Func<string, T> func)
        {
            int StartProgramCursorPosition = Console.CursorTop;
            try
            {
                return func(message);
            }
            catch (Exception exception)
            {
                PrintAndPause("Error! " + exception.Message);
                ClearPreviousNLines(Console.CursorTop - StartProgramCursorPosition);
            }

            return ReadInputUntillCorrect(message, func);
        }
        
        public static void PrintAndPause(string message, ConsoleColor color = ConsoleColor.White)
        {
            PrintConsoleMessageWithColor(message, color);
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

        public static void ExecuteMethodUntilItReturnsTrue(Func<bool> method)
        {
            int CurrentCursorPosition = Console.CursorTop;
            bool IsExecuteMethodAgain = false;
            do
            {
                IsExecuteMethodAgain = method();
                if (IsExecuteMethodAgain)
                {
                    ClearPreviousNLines(Console.CursorTop - CurrentCursorPosition);
                }
            } while (IsExecuteMethodAgain);
        }
    }
}
