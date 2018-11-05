using System;
using UtilityLibraries;

namespace DistanceBetweenPoints
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
            //    по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            //        Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
            //б) *оформить вычисления расстояния между точками в виде метода;

            Console.WriteLine("Программа рассчета расстояния между точками.");

            double? Point1X = null;
            double? Point1Y = null;

            double? Point2X = null;
            double? Point2Y = null;

            while (Point1X == null || Point1Y == null || Point2X == null || Point2Y == null)
            {
                try
                {
                    if (Point1X == null)
                    {
                        ConsoleHelper.ReadAndAssignInput("Введите координату X первой точки", ref Point1X);
                    }
                    if (Point1Y == null)
                    {
                        ConsoleHelper.ReadAndAssignInput("Введите координату Y первой точки", ref Point1Y);
                    }
                    if (Point2X == null)
                    {
                        ConsoleHelper.ReadAndAssignInput("Введите координату X второй точки", ref Point2X);
                    }
                    if (Point2Y == null)
                    {
                        ConsoleHelper.ReadAndAssignInput("Введите координату Y второй точки", ref Point2Y);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ошибка ввода! " + exception.Message);
                }
            }

            double distance = CalculateDistance(Point1X ?? 0, Point1Y ?? 0, Point2X ?? 0, Point2Y ?? 0);
            Console.WriteLine($"Расстояние между точками ({Point1X},{Point1Y}), ({Point2X},{Point2X}): {distance:F2}");
            Console.ReadKey();
        }

        private static double CalculateDistance(double point1X, double point1Y, double point2X, double point2Y)
        {
            return Math.Sqrt(Math.Pow(point2X - point1X, 2) + Math.Pow(point2Y - point1Y, 2));
        }
    }
}
