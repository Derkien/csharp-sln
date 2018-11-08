using System;

namespace GB1Lesson2
{
    internal partial class Program
    {
        private const string ValidPassword = "GeekBrains";
        private const string ValidLogin = "root";
        private const int MaxTry = 3;

        private static TaskReturnCode ExecuteTask4Solution()
        {
            //  4.Реализовать метод проверки логина и пароля.
            //    На вход метода подается логин и пароль.
            //    На выходе истина, если прошел авторизацию, и ложь, если не прошел
            //    (Логин: root, Password: GeekBrains). 
            //    Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
            //    программа пропускает его дальше или не пропускает.
            //    С помощью цикла do while ограничить ввод пароля тремя попытками.
            Console.WriteLine("Please enter your user login and password below");

            bool CredentialsIsValid = false;
            int TryLeft = MaxTry;
            string UserLogin;
            string UserPassword;
            do
            {
                UserLogin = GetUserInput("Login");
                UserPassword = GetUserInput("Password");
                CredentialsIsValid = CheckCredentials(UserLogin, UserPassword);

                if (CredentialsIsValid)
                {
                    break;
                }

                Console.WriteLine($"Invalid user login or password. Attempts left: {--TryLeft}");
            } while (!CredentialsIsValid && TryLeft > 0);

            if (CredentialsIsValid)
            {
                UtilityLibraries.ConsoleHelper.PrintAndPause($"Hello, user {UserLogin}!");
            }
            else if (TryLeft == 0)
            {
                UtilityLibraries.ConsoleHelper.PrintAndPause("Failed to login.");
            }

            return TaskReturnCode.Continue;

        }

        private static bool CheckCredentials(string login, string password)
        {
            return login == ValidLogin && password == ValidPassword;
        }

        private static string GetUserInput(string message)
        {
            try
            {
                return UtilityLibraries.ConsoleHelper.ReadAnyNonEmptyString(message);
            }
            catch (Exception)
            {
                UtilityLibraries.ConsoleHelper.PrintAndPause("This value can't be emtpy!");
            }

            return GetUserInput(message);
        }
    }
}
