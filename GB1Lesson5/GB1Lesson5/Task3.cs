using System;
using System.Collections.Generic;
using UtilityLibraries;

namespace GB1Lesson5
{
    /// <summary>
    /// *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. 
    /// Например: badc являются перестановкой abcd.
    /// </summary>
    internal partial class Program
    {
        private static TaskReturnCode ExecuteTask3Solution()
        {
            ConsoleHelper.PrintAndPause("Task3 - Program will check two strings if one can be created from symbols of another and both of equal length");
            ConsoleHelper.ExecuteMethodUntilItReturnsTrue(RunTask3Solution);

            return TaskReturnCode.Continue;
        }

        private static bool RunTask3Solution()
        {
            string String1 = ConsoleHelper.ReadInputUntillCorrect("Enter any string", ConsoleHelper.ReadAnyNonEmptyString);
            string String2 = "";

            ConsoleHelper.ExecuteMethodUntilItReturnsTrue(() => ReadStringOfGivenLength(String1.Length, out String2));

            Console.WriteLine($"Ok, lets see... Two strings\r\n'{String1}'\r\nand\r\n'{String2}'");

            bool CheckStringsResult = CheckStrings(String1, String2);

            Console.WriteLine($"Answer: second string {(CheckStringsResult ? "can be" : "can't be")} created from symbols of first");

            string UserAnswer = ConsoleHelper.ReadInputUntillCorrect("Whant to check one more time? (y/n)", ConsoleHelper.ReadAnyNonEmptyString);

            return (UserAnswer.ToLower() == "y");
        }

        private static bool ReadStringOfGivenLength(int length, out string outString)
        {
            string String = ConsoleHelper.ReadInputUntillCorrect($"Entery another string, with total length: {length}", ConsoleHelper.ReadAnyNonEmptyString);
            outString = String;

            return String.Length != length;
        }

        private static bool CheckStrings(string string1, string string2)
        {
            List<char> StringChars1 = new List<char>();
            StringChars1.AddRange(string1);
            List<char> StringChars2 = new List<char>();
            StringChars2.AddRange(string2);

            foreach (var stringChar in StringChars1)
            {
                if (!StringChars2.Contains(stringChar))
                {
                    return false;
                }
                else
                {
                    StringChars2.Remove(stringChar);
                }
            }

            return true;
        }
    }
}
