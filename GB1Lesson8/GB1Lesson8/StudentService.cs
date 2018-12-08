using GB1Lesson8.DBModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace GB1Lesson8
{
    public class StudentService
    {
        public const string AvailableImportFileExtensionsFilter = "Только *.CSV|*.CSV";

        public List<Student> GetStudentsListFromFile(string filename, out string logFilePath)
        {
            List<string> ParseErrors = new List<string>() { };
            List<Student> List = new List<Student>();
            using (StreamReader StreamReader = new StreamReader(filename))
            {
                if (StreamReader.Peek() == -1)
                {
                    ParseErrors.Add($"File {filename} is empty");
                }

                while (StreamReader.Peek() >= 0)
                {
                    try
                    {
                        // TODO: add another separators
                        string[] s = StreamReader.ReadLine().Split(';');
                        // Simple parse of file... 
                        // TODO: extend checking students data
                        List.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), s[7], s[8]));
                    }
                    catch (Exception exception)
                    {
                        ParseErrors.Add(PrepareLogDataFromException(exception));
                    }
                }
            }

            SaveParseErrors(ParseErrors, out logFilePath);

            return List;
        }

        private static string PrepareLogDataFromException(Exception exception)
        {
            return $"Error: {exception.Message}; Exception: {exception.ToString()}";
        }

        public void SaveParseErrors(Exception exception, out string logFileName)
        {
            SaveParseErrors(new List<string>() { PrepareLogDataFromException(exception) }, out logFileName);
        }

        public void SaveParseErrors(List<string> parseErrors, out string logFileName)
        {
            logFileName = "";

            if (parseErrors.Count > 0)
            {
                string fileName = Path.GetRandomFileName();
                string LogFilePath = Path.Combine(Path.GetTempPath(), fileName);
                LogFilePath = Path.ChangeExtension(LogFilePath, "log");

                using (StreamWriter file = new StreamWriter(@LogFilePath))
                {
                    foreach (var item in parseErrors)
                    {
                        file.WriteLine(item);
                    }
                }
                logFileName = $"Error log at: {LogFilePath}";
            }
        }
    }
}
