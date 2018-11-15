using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB1Lesson4
{
    public class TwoDimentionalArray
    {
        private readonly Random Random = new Random();

        /// <summary>
        /// Реализовать конструктор, заполняющий массив случайными числами. 
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        public TwoDimentionalArray(uint numberOfRows, uint numberOfColumns, int minValue, int maxValue)
        {
            CheckDimentions(numberOfRows, numberOfColumns);
            Data = new int[numberOfRows, numberOfColumns];
            for (uint i = 0; i < numberOfRows; i++)
            {
                for (uint j = 0; j < numberOfColumns; j++)
                {
                    Data[i, j] = Random.Next(minValue, maxValue);
                }
            }
        }

        public TwoDimentionalArray(uint numberOfRows, uint numberOfColumns, int maxValue)
        {
            CheckDimentions(numberOfRows, numberOfColumns);
            Data = new int[numberOfRows, numberOfColumns];
            for (uint i = 0; i < numberOfRows; i++)
            {
                for (uint j = 0; j < numberOfColumns; j++)
                {
                    Data[i, j] = Random.Next(maxValue);
                }
            }
        }

        public TwoDimentionalArray(uint numberOfRows, uint numberOfColumns)
        {
            CheckDimentions(numberOfRows, numberOfColumns);
            Data = new int[numberOfRows, numberOfColumns];
            for (uint i = 0; i < numberOfRows; i++)
            {
                for (uint j = 0; j < numberOfColumns; j++)
                {
                    Data[i, j] = Random.Next();
                }
            }
        }

        /// <summary>
        /// ** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        /// </summary>
        /// <param name="fileName"></param>
        public TwoDimentionalArray(string fileName)
        {
            // not good because need two reads of file
            (uint rowsTotal, uint columnsTotal) = ParseDimentions(fileName);
            CheckDimentions(rowsTotal, columnsTotal);

            Data = new int[rowsTotal, columnsTotal];
            foreach (var (row, column, value) in ReadFileSafe(fileName))
            {
                Data[row, column] = value;
            }
        }

        public int[,] Data { get; }

        private void CheckDimentions(uint numberOfRows, uint numberOfColumns)
        {
            if (numberOfRows == 0 || numberOfColumns == 0)
            {
                throw new ArgumentException("Cant create zero length two-dim array");
            }
        }

        private static IEnumerable<(int row, int column, int value)> ReadFileSafe(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            int CurrentRow = 0;
            bool ColumnsLimitIsSet = false;
            int ColumnsLimit = 0;
            using (StreamReader StreamReader = new StreamReader(fileName))
            {
                if (StreamReader.Peek() == -1)
                {
                    throw new ArgumentException($"File {fileName} is empty");
                }

                while (StreamReader.Peek() >= 0)
                {
                    string LineToParse = StreamReader.ReadLine();

                    string[] Tokens = LineToParse.Split(',');

                    // check file columns with values start from first line is same
                    if (!ColumnsLimitIsSet)
                    {
                        ColumnsLimit = Tokens.Length;

                        if (ColumnsLimit == 0)
                        {
                            throw new ArgumentException($"Invalid number of columns in {fileName} at row {CurrentRow + 1}, must be 1 or more colmuns");
                        }
                    }

                    if (Tokens.Length != ColumnsLimit)
                    {
                        throw new ArgumentException($"Invalid number of columns in {fileName} at row {CurrentRow + 1}, must be {ColumnsLimit} colmuns");
                    }

                    int[] ParsedIntegers;
                    try
                    {
                        ParsedIntegers = Array.ConvertAll(Tokens, int.Parse);
                    }
                    catch
                    {
                        throw new ArgumentException($"File {fileName} contains invalid data at row {CurrentRow + 1}");
                    }

                    for (int i = 0; i < ParsedIntegers.Length; i++)
                    {
                        yield return (row: CurrentRow, column: i, value: ParsedIntegers[i]);
                    }

                    CurrentRow++;
                }
            }
        }

        private static (uint rowsTotal, uint columnsTotal) ParseDimentions(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            uint RowsTotal = 0;
            uint ColumnsTotal = 0;

            bool ColumnsLimitIsSet = false;

            using (StreamReader StreamReader = new StreamReader(fileName))
            {
                if (StreamReader.Peek() == -1)
                {
                    throw new ArgumentException($"File {fileName} is empty");
                }

                while (StreamReader.Peek() >= 0)
                {
                    RowsTotal++;

                    string LineToParse = StreamReader.ReadLine();
                    if (!ColumnsLimitIsSet)
                    {
                        string[] Tokens = LineToParse.Split(',');

                        ColumnsTotal = (uint)Tokens.Length;

                        if (ColumnsTotal == 0)
                        {
                            throw new ArgumentException($"Invalid number of columns in {fileName} at row {RowsTotal}, must be 1 or more colmuns");
                        }
                    }
                }

            }

            return (rowsTotal: RowsTotal, columnsTotal: ColumnsTotal);
        }


        public string OtputdataToDirectory(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            string fileName = Path.GetRandomFileName();
            string pathString = Path.Combine(folderName, fileName);

            /// [Debug]
            // Console.WriteLine($"Path to file: {pathString}");

            using (StreamWriter file = new StreamWriter(@pathString))
            {
                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    string line = "";

                    for (int j = 0; j < Data.GetLength(1); j++)
                    {
                        line += Data[i, j] + ",";
                    }

                    line = line.TrimEnd(',');
                    file.WriteLine(line);

                    /// [Debug]
                    // Console.WriteLine(line);
                }
            }

            return pathString;
        }

        /// <summary>
        /// Создать метод, который возвращаeт: сумму всех элементов массива;
        /// (через параметры, используя модификатор ref или out).
        /// </summary>
        public void Sum(out int sum)
        {
            sum = Sum();
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    sum += Data[i, j];
                }
            }

            return sum;
        }

        /// <summary>
        /// Создать метод, который возвращаeт: сумму всех элементов массива больше заданного;
        /// (через параметры, используя модификатор ref или out).
        /// </summary>
        public void SumElementsGreaterThanProvided(int lowBorderValue, out int sum)
        {
            sum = SumElementsGreaterThanProvided(lowBorderValue);
        }

        public int SumElementsGreaterThanProvided(int lowBorderValue)
        {
            int sum = 0;
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    sum += Data[i, j] > lowBorderValue ? Data[i, j] : 0;
                }
            }

            return sum;
        }

        /// <summary>
        /// свойство, возвращающее минимальный элемент массива;
        /// </summary>
        public int MinElement
        {
            get
            {
                int minElement = Data[0, 0];

                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    for (int j = 0; j < Data.GetLength(1); j++)
                    {
                        if (Data[i, j] < minElement)
                        {
                            minElement = Data[i, j];
                        }
                    }
                }

                return minElement;
            }
        }


        /// <summary>
        /// свойство, возвращающее максимальный элемент массива;
        /// </summary>
        public int MaxElement
        {
            get
            {
                int maxElement = Data[0, 0];

                for (int i = 0; i < Data.GetLength(0); i++)
                {
                    for (int j = 0; j < Data.GetLength(1); j++)
                    {
                        if (Data[i, j] > maxElement)
                        {
                            maxElement = Data[i, j];
                        }
                    }
                }

                return maxElement;
            }
        }

        /// <summary>
        /// Создать метод, который возвращаeт: номер максимального элемента массива;
        /// (через параметры, используя модификатор ref или out)
        /// </summary>
        public void GetMaxElementIndex(out int row, out int column)
        {
            row = 0;
            column = 0;

            int maxElement = Data[0, 0];
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    if (Data[i, j] > maxElement)
                    {
                        maxElement = Data[i, j];
                        row = i;
                        column = j;
                    }
                }
            }
        }

        public override string ToString()
        {
            char[] charsToTrim = { ',', ' ' };
            string s = "";

            for (int i = 0; i < Data.GetLength(0); i++)
            {
                s += "{";
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    s += Data[i, j] + ",";
                }
                s = s.TrimEnd(charsToTrim);
                s += "}, ";
            }

            s = s.TrimEnd(charsToTrim);

            return $"{{{s}}}";
        }
    }
}
