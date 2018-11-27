using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UtilityLibraries;

namespace GB1Lesson6
{

    /// <summary>
    /// 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
    /// а) Сделать меню с различными функциями и представить пользователю выбор, 
    ///     для какой функции и на каком отрезке находить минимум.
    ///     Использовать массив(или список) делегатов, в котором хранятся различные функции.
    /// б) Переделать метод Load, чтобы он возвращал коллекцию List<double> считанных значений.
    ///     Пусть метод возвращает минимум через параметр(с использованием модификатора out). 
    /// </summary>
    internal partial class Program
    {
        private delegate IList<double> DoubleReader(string fileName, out double minValue, int startPosition, int endPosition);

        private static Random random = new Random();

        private const string BinaryFileName = "data.bin";

        private enum SubMenuKey
        {
            Func1 = 1,
            Func2 = 2,
            Func3 = 3,
            Func4 = 4,
            Func5 = 5,
            Exit = 8,
        }

        private static IReadOnlyDictionary<uint, string> SubMenuTextBySubMenuKey = new Dictionary<uint, string> {
            { (byte)SubMenuKey.Func1, "Find min on [16,64]"},
            { (byte)SubMenuKey.Func2, "Find min on [32,96]"},
            { (byte)SubMenuKey.Func3, "Find min on [64,128]"},
            { (byte)SubMenuKey.Func4, "Find min on [0,200]"},
            { (byte)SubMenuKey.Func5, "Generate new random binary list"},
            { (byte)SubMenuKey.Exit, "return to main menu"}
        };

        private static IReadOnlyDictionary<uint, Func<TaskReturnCode>> SubMenuActionBySubMenuKey = new Dictionary<uint, Func<TaskReturnCode>> {
            { (byte)SubMenuKey.Func1, () => ExecuteDoubleReaderTask(BinaryFileName, 16, 64) },
            { (byte)SubMenuKey.Func2, () => ExecuteDoubleReaderTask(BinaryFileName, 32, 96) },
            { (byte)SubMenuKey.Func3, () => ExecuteDoubleReaderTask(BinaryFileName, 64, 128) },
            { (byte)SubMenuKey.Func4, () => ExecuteDoubleReaderTask(BinaryFileName, 0, 200) },
            { (byte)SubMenuKey.Func5, () => GenerateBinaryListOfRandomDoublesTask(BinaryFileName, 1, 200) },
        };

        private static TaskReturnCode ExecuteTask2Solution()
        {
            GenerateBinaryListOfRandomDoubles(BinaryFileName, 1, 200);

            PrintSubMenuUntilExitKeyNotPressed();

            return TaskReturnCode.Continue;
        }

        private static void PrintSubMenuUntilExitKeyNotPressed()
        {
            TaskReturnCode CurrentTaskReturnCode = TaskReturnCode.Continue;
            do
            {
                uint UserChoice = ConsoleHelper.PrintMenuAndReadChoice(SubMenuTextBySubMenuKey);
                if (SubMenuActionBySubMenuKey.ContainsKey(UserChoice))
                {
                    CurrentTaskReturnCode = SubMenuActionBySubMenuKey[UserChoice]();
                }
                else if(UserChoice == (byte)SubMenuKey.Exit)
                {
                    break;
                }
                else
                {
                    ConsoleHelper.PrintAndPause("Invalid choise");
                }
            } while (CurrentTaskReturnCode != TaskReturnCode.Exit);
        }

        private static TaskReturnCode ExecuteDoubleReaderTask(string fileName, int rangeStart, int rangeEnd)
        {
            List<double> ResultList = new List<double>(Load(fileName, out double minValue, rangeStart, rangeEnd));
            StringBuilder builder = new StringBuilder();
            foreach (double doubleValue in ResultList)
            {
                builder.Append(doubleValue).Append(" ");
            }
            ConsoleHelper.PrintAndPause($"Min: {minValue} From range: {builder.ToString().TrimEnd(' ')}");

            return TaskReturnCode.Continue;
        }

        private static IList<double> Load(string fileName, out double minValue, int startPosition, int endPosition)
        {
            List<double> ReadValues = new List<double>();

            using (BinaryReader BinaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
            {
                minValue = double.MaxValue;
                int Lenght = (int)BinaryReader.BaseStream.Length;
                int Position = startPosition;
                double d;

                BinaryReader.BaseStream.Seek(Position, SeekOrigin.Begin);

                while (Position < Lenght && Position < endPosition)
                {
                    d = BinaryReader.ReadDouble();
                    ReadValues.Add(d);
                    if (d < minValue)
                    {
                        minValue = d;
                    }

                    Position += sizeof(double);
                }
            }

            return ReadValues;
        }

        private static TaskReturnCode GenerateBinaryListOfRandomDoublesTask(string fileName, double a, double b)
        {
            ConsoleHelper.PrintConsoleMessageWithColor("Generating list...", ConsoleColor.Magenta);

            var StopWatch = System.Diagnostics.Stopwatch.StartNew();

            GenerateBinaryListOfRandomDoubles(fileName, a, b);

            StopWatch.Stop();
            TimeSpan TimeSpan = StopWatch.Elapsed;

            ConsoleHelper.PrintAndPause($"List successfull generatet in: {TimeSpan.Minutes}m {TimeSpan.Seconds}s {TimeSpan.Milliseconds}ms", ConsoleColor.Magenta);

            return TaskReturnCode.Continue;
        }

        private static void GenerateBinaryListOfRandomDoubles(string fileName, double a, double b)
        {
            using (BinaryWriter BinaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
            {
                double x = a;
                while (x <= b)
                {
                    BinaryWriter.Write((double)random.Next((int)a, (int)b));
                    x++;
                }
            }
        }
    }
}