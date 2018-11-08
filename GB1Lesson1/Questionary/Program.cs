using System;
using UtilityLibraries;

namespace Questionary
{
    internal class Program
    {
        private const int ChoiceOutputConcat = 1;
        private const int ChoiceOutputPreformat = 2;
        private const int ChoiceOutputWithSpecialSign = 3;
        private const int ChoiceOutputAtCenter = 4;
        private const int ChoiceExit = 9;

        private const int ConsoleWindowWidth = 60;
        private const int ConsoleWindowHeight = 30;

        private static void Main(string[] args)
        {
            // Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес).
            // В результате вся информация выводится в одну строчку.
            // а) используя склеивание;
            // б) используя форматированный вывод;
            // в) *используя вывод со знаком $.

            // добавил задание n5
            //а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            //б) Сделать задание, только вывод организуйте в центре экрана
            //в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)

            string UserName = "";
            string UserSurname = "";
            string UserCity = "";
            uint UserAge = 0;
            uint UserHeight = 0;
            double UserWeight = 0;

            int ValidConsoleWindowWidth = ConsoleWindowWidth > Console.LargestWindowWidth ? Console.LargestWindowWidth : ConsoleWindowWidth;
            int ValidConsoleWindowHeight = ConsoleWindowHeight > Console.LargestWindowHeight ? Console.LargestWindowHeight : ConsoleWindowHeight;

            Console.SetWindowSize(ValidConsoleWindowWidth, ValidConsoleWindowHeight);
            Console.SetBufferSize(ValidConsoleWindowWidth, ValidConsoleWindowHeight);

            Console.WriteLine("Заполните анкету.");

            do
            {
                try
                {
                    if (string.IsNullOrEmpty(UserName))
                    {
                        ConsoleHelper.ReadAndAssignInput("Ваш имя:", ref UserName);
                    }
                    if (string.IsNullOrEmpty(UserSurname))
                    {
                        ConsoleHelper.ReadAndAssignInput("Ваша фамилия:", ref UserSurname);
                    }
                    if (string.IsNullOrEmpty(UserCity))
                    {
                        ConsoleHelper.ReadAndAssignInput("Город проживания:", ref UserCity);
                    }
                    if (UserAge <= 0)
                    {
                        ConsoleHelper.ReadAndAssignInput("Ваш возраст (полных лет):", ref UserAge);
                    }
                    if (UserHeight <= 0)
                    {
                        ConsoleHelper.ReadAndAssignInput("Ваш рост, см:", ref UserHeight);
                    }
                    if (UserWeight <= 0)
                    {
                        ConsoleHelper.ReadAndAssignInput("Ваш вес, кг:", ref UserWeight);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ошибка ввода! " + exception.Message);
                }
            } while (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserSurname) || UserAge <= 0 || UserHeight <= 0 || UserWeight <= 0);

            Console.Clear();
            Console.WriteLine("Анкета заполнена!");

            uint UserChoice = 0;
            while (UserChoice != ChoiceExit)
            {
                UserChoice = PrintMenuAndReturnChoice();

                switch (UserChoice)
                {
                    case ChoiceOutputConcat:
                        ConsoleHelper.PrintConsoleMessageWithColor("Имя: " + UserName + "; Фамилия: " + UserSurname + ";\r\nВозраст: " + UserAge + "; Рост: " + UserHeight + " см; Вес: " + UserWeight + " кг;\r\nГород: " + UserCity, ConsoleColor.Gray);
                        break;
                    case ChoiceOutputPreformat:
                        ConsoleHelper.PrintConsoleMessageWithColor(string.Format("Имя: {0}; Фамилия: {1};\r\nВозраст: {2}; Рост: {3} см; Вес: {4} кг;\r\nГород: {5}", UserName, UserSurname, UserAge, UserHeight, UserWeight, UserCity), ConsoleColor.Magenta);
                        break;
                    case ChoiceOutputWithSpecialSign:
                        ConsoleHelper.PrintConsoleMessageWithColor($"Имя: {UserName}; Фамилия: {UserSurname};\r\nВозраст: {UserAge}; Рост: {UserHeight} см; Вес: {UserWeight} кг;\r\nГород: {UserCity}", ConsoleColor.Cyan);
                        break;
                    case ChoiceOutputAtCenter:
                        ConsoleHelper.PrintConsoleMessageAtTheMiddle("Имя", UserName);
                        ConsoleHelper.PrintConsoleMessageAtTheMiddle("Фамилия", UserSurname);
                        ConsoleHelper.PrintConsoleMessageAtTheMiddle("Возраст", UserAge.ToString());
                        ConsoleHelper.PrintConsoleMessageAtTheMiddle("Рост, см", UserHeight.ToString());
                        ConsoleHelper.PrintConsoleMessageAtTheMiddle("Вес, кг", UserWeight.ToString());
                        ConsoleHelper.PrintConsoleMessageAtTheMiddle("Город", UserCity);
                        break;
                    case ChoiceExit:
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Команда не распознана!");
                        break;
                }

                Console.ReadKey();
            }
        }

        private static uint PrintMenuAndReturnChoice()
        {
            uint СommandChoice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(
                    "Выберите вариант вывода анкетных данных и нажмите Enter:\r\n" +
                    $"{ChoiceOutputConcat}. используя склеивание\r\n" +
                    $"{ChoiceOutputPreformat}. используя форматированный вывод\r\n" +
                    $"{ChoiceOutputWithSpecialSign}. * используя вывод со знаком $\r\n" +
                    $"{ChoiceOutputAtCenter}. вывести по центру экрана\r\n" +
                    $"для выхода введите {ChoiceExit} \r\n"
                );
                try
                {
                    ConsoleHelper.ReadAndAssignInput("Ваш выбор:", ref СommandChoice);
                    break;
                }
                catch
                {
                    Console.WriteLine("Нужно ввести число! Для повтора, нажмите любую клавишу.");
                    Console.ReadKey();
                }
            }

            return СommandChoice;
        }
    }
}
