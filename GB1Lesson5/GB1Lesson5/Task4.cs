using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UtilityLibraries;

namespace GB1Lesson5
{
    /// <summary>
    ///  *Задача ЕГЭ.
    ///  На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
    ///  В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
    ///  <Фамилия> <Имя> <оценки>, где 
    ///  <Фамилия> — строка, состоящая не более чем из 20 символов, 
    ///  <Имя> — строка, состоящая не более чем из 15 символов, 
    ///  <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
    ///  
    ///  <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
    ///  Иванов Петр 4 5 3
    ///  Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
    ///  Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
    /// </summary>
    internal partial class Program
    {
        private enum StudentMarkDictionaryKey { Marks, AverageMarks }

        private const int MaxNumberOfMarks = 3;
        private const int MaxNumberOfStudentsData = 100;

        private const string GroupNameSurname = "surname";
        private const string GroupNameName = "name";
        private const string GroupNameMarkOne = "markOne";
        private const string GroupNameMarkTwo = "markTwo";
        private const string GroupNameMarkThree = "markThree";

        private const string PatternSurname = "?<" + GroupNameSurname + @">[\p{IsCyrillic}]{1,20}";
        private const string PatternName = "?<" + GroupNameName + @">[\p{IsCyrillic}]{1,15}";
        private const string PatternMarkOne = "?<" + GroupNameMarkOne + @">[\d]{1}";
        private const string PatternMarkTwo = "?<" + GroupNameMarkTwo + @">[\d]{1}";
        private const string PatternMarkThree = "?<" + GroupNameMarkThree + @">[\d]{1}";

        private const string FileLineCheckRegex = "^(" + PatternSurname + ") (" + PatternName + ") (" + PatternMarkOne + ") (" + PatternMarkTwo + ") (" + PatternMarkThree + ")$";

        private static TaskReturnCode ExecuteTask4Solution()
        {
            ConsoleHelper.PrintAndPause(
                "Task4 - Program will read files with students marks"
                + "\r\nFile contains:"
                + "\r\n1st line is number of students"
                + "\r\n2nd and next up 10 < N < 100 lines is <Surname>{1,20}, <Name>{1,15}, <marks>[\\d ]{5} - all separated by space"
                + "\r\nResult: output worst 3 students by average marks (or more if average is the same)"
            );
            ConsoleHelper.ExecuteMethodUntilItReturnsTrue(RunTask4Solution);

            return TaskReturnCode.Continue;
        }

        protected static bool RunTask4Solution()
        {
            List<string> ParsedErrors = new List<string>();
            var Students = new Dictionary<string, string>();
            var StudentsWithLowMarks = new Dictionary<string, Dictionary<StudentMarkDictionaryKey, string>>();

            float MaxAverageMark = 5;
            SortedList<float, float> AverageMarks = new SortedList<float, float>();

            string PathToFile = ConsoleHelper.ReadInputUntillCorrect("Enter path to file with students marks", ConsoleHelper.ReadAnyNonEmptyString);

            foreach (var (user, marks) in ReadFileSafe(PathToFile, ParsedErrors))
            {
                var StudentAverageMark = (marks.markOne + marks.markTwo + marks.markThree) / (float)MaxNumberOfMarks;

                if (StudentAverageMark == MaxAverageMark)
                {
                    continue;
                }

                if (!AverageMarks.ContainsKey(StudentAverageMark))
                {
                    AverageMarks.Add(StudentAverageMark, StudentAverageMark);
                }

                string CurrentStudentSurname = char.ToUpper(user.surname[0]) + user.surname.Substring(1);
                string CurrentStudentName = char.ToUpper(user.name[0]) + user.name.Substring(1);
                string CurrentStudientsHash = CurrentStudentSurname + CurrentStudentName + StudentAverageMark.ToString();

                Students.Add(CurrentStudientsHash, $"{CurrentStudentSurname} {CurrentStudentName}");

                var CurrentStudentMarks = new Dictionary<StudentMarkDictionaryKey, string>
                {
                    { StudentMarkDictionaryKey.AverageMarks, StudentAverageMark.ToString() },
                    { StudentMarkDictionaryKey.Marks, $"{marks.markOne} {marks.markTwo} {marks.markThree}" }
                };

                StudentsWithLowMarks.Add(CurrentStudientsHash, CurrentStudentMarks);
            }

            if (ParsedErrors.Count > 0)
            {
                PrintErrors(ParsedErrors);
                Console.WriteLine("Information collected only from correct data.");
            } else
            {
                Console.WriteLine("File parsed succesfully! All data is valid!");
            }


            ShowResults(Students, StudentsWithLowMarks, AverageMarks.Keys);

            string UserAnswer = ConsoleHelper.ReadInputUntillCorrect("Check another document? (y/n)", ConsoleHelper.ReadAnyNonEmptyString);

            return (UserAnswer.ToLower() == "y");
        }

        private static void PrintErrors(List<string> ParsedErrors)
        {
            Console.WriteLine("Errors occured while processing file:");
            foreach (var item in ParsedErrors)
            {
                Console.WriteLine(item);
            }
        }

        private static void ShowResults(Dictionary<string, string> Students, Dictionary<string, Dictionary<StudentMarkDictionaryKey, string>> StudentsWithLowMarks, IList<float> AverageMarksKeys)
        {
            int i = 0;
            foreach (var AverageMark in AverageMarksKeys)
            {
                foreach (var studentHash in Students.Keys)
                {
                    float StudentAverage = float.Parse(StudentsWithLowMarks[studentHash][StudentMarkDictionaryKey.AverageMarks]);
                    string StudentMarks = StudentsWithLowMarks[studentHash][StudentMarkDictionaryKey.Marks];

                    if (CompareFloats(StudentAverage, AverageMark))
                    {
                        Console.WriteLine($"Name: {Students[studentHash]}; Marks: {StudentMarks}; Average: {StudentAverage:F2}");
                        i++;
                    }
                }

                if (i >= 3)
                {
                    break;
                }
            }
        }

        private static bool CompareFloats(float numberOne, float numberTwo)
        {
            float difference = Math.Abs(numberOne * .0001f);

            return (Math.Abs(numberOne - numberTwo) <= difference);
        }


        private static IEnumerable<((string surname, string name) user, (int markOne, int markTwo, int markThree) marks)> ReadFileSafe(string fileName, List<string> ParseErrors)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader StreamReader = new StreamReader(fileName))
            {
                if (StreamReader.Peek() == -1)
                {
                    throw new ArgumentException($"File {fileName} is empty");
                }

                Regex CheckLineRegex = new Regex(FileLineCheckRegex);

                int CurrentRow = 0;
                int TotalStudentsWithSuccessData = 0;
                int TotalStudentsWithAnyData = 0;
                int StudentsLimitProvidedInFile = 0;
                while (StreamReader.Peek() >= 0)
                {
                    CurrentRow++;
                    string LineToParse = StreamReader.ReadLine();
                    if (CurrentRow == 1)
                    {
                        if (!int.TryParse(LineToParse, out StudentsLimitProvidedInFile))
                        {
                            ParseErrors.Add($"Invalid data at first line! Must be number of students!");

                            break;
                        }

                        if (StudentsLimitProvidedInFile > MaxNumberOfStudentsData)
                        {
                            ParseErrors.Add($"Limit of students data exceeded!");

                            break;
                        }

                        continue;
                    }

                    if (CurrentRow > StudentsLimitProvidedInFile + 1)
                    {
                        break;
                    }

                    if (!CheckLineRegex.IsMatch(LineToParse))
                    {
                        ParseErrors.Add($"Invalid data at line {CurrentRow}");

                        TotalStudentsWithAnyData++;

                        continue;
                    }

                    Match match = CheckLineRegex.Match(LineToParse);

                    string GroupNameSurnameValue = match.Groups[GroupNameSurname].Value.ToLower();
                    string GroupNameNameValue = match.Groups[GroupNameName].Value.ToLower();
                    int GroupNameMarkOneValue = int.Parse(match.Groups[GroupNameMarkOne].Value);
                    int GroupNameMarkTwoValue = int.Parse(match.Groups[GroupNameMarkTwo].Value);
                    int GroupNameMarkThreeValue = int.Parse(match.Groups[GroupNameMarkThree].Value);

                    yield return (
                        user: (surname: GroupNameSurnameValue, name: GroupNameNameValue),
                        marks: (markOne: GroupNameMarkOneValue, markTwo: GroupNameMarkTwoValue, markThree: GroupNameMarkThreeValue)
                    );

                    TotalStudentsWithSuccessData++;
                    TotalStudentsWithAnyData++;
                }

                if (
                    CurrentRow != TotalStudentsWithAnyData + 1
                    || CurrentRow != TotalStudentsWithSuccessData + 1
                    || CurrentRow != StudentsLimitProvidedInFile + 1
                )
                {
                    ParseErrors.Add("Invalid number of students data! " +
                        $"Provided: {CurrentRow - 1}, expected: {StudentsLimitProvidedInFile}, processed: {TotalStudentsWithAnyData}, success: {TotalStudentsWithSuccessData}");
                }
            }
        }
    }
}
