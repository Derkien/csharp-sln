using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа перестановки двух переменных.");

            // через 3ю переменную любые строки/числа
            string anyStringA = "Abcd";
            string anyStringB = "Efgh";

            Console.WriteLine($"Переменная A до: {anyStringA}, Переменная B до: {anyStringB}");
            string anyStringC = anyStringA;
            anyStringA = anyStringB;
            Console.WriteLine("Запишем A в C, затем B в A, а потом C в B");
            anyStringB = anyStringC;
            Console.WriteLine($"Переменная A после: {anyStringA}, Переменная B после: {anyStringB}, Переменная С: {anyStringC}");

            // без использования 3й переменной только числа
            int intA = 1;
            int intB = 5;

            Console.WriteLine($"Число A до: {intA}, Число B до: {intB}");
            Console.WriteLine("Присвоим B сумму A и B. Присвоим А разницу B и A. Присвоим B разницу B и A.");
            intB = intB + intA;
            intA = intB - intA;
            intB = intB - intA;
            Console.WriteLine($"Число A после: {intA}, Число B после: {intB}");

            Console.ReadKey();
        }
    }
}
