using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibraries
{
    public static class ConsoleHelper
    {
        public static void ReadAndAssignInput(string message, ref string value)
        {
            Console.WriteLine(message);
            value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Нужно ввести любую строку");
            }
        }

        public static void ReadAndAssignInput(string message, ref uint value)
        {
            Console.WriteLine(message);
            bool ParseIsSuccess = uint.TryParse(Console.ReadLine(), out value);
            if (!ParseIsSuccess || value <= 0)
            {
                throw new Exception("Нужно ввести целое число больше нуля");
            }
        }

        public static void ReadAndAssignInput(string message, ref double value)
        {
            Console.WriteLine(message);
            bool ParseIsSuccess = double.TryParse(Console.ReadLine().Replace(",", "."), out value);
            if (!ParseIsSuccess || value <= 0)
            {
                throw new Exception("Нужно ввести число больше нуля");
            }
        }

        public static void ReadAndAssignInput(string message, ref double? value)
        {
            Console.WriteLine(message);
            bool ParseIsSuccess = double.TryParse(Console.ReadLine().Replace(",", "."), out double inputValue);
            if (!ParseIsSuccess)
            {
                throw new Exception("Нужно ввести число!");
            }

            value = inputValue;
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
    }
}
