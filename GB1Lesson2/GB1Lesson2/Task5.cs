using System;
using System.Collections.Generic;
using UtilityLibraries;

namespace GB1Lesson2
{
    internal partial class Program
    {
        //private static NameValueCollection WeightLimits = 
        private enum DiagnosisType
        {
            Type1,
            Type2,
            Type3,
            Type4,
            Type5,
            Type6,
            Type7,
            Type8,
        }

        private static IReadOnlyDictionary<DiagnosisType, string> DiagnosisByDiagnosisKey = new Dictionary<DiagnosisType, string> {
            {DiagnosisType.Type1, "Анорексия нервная. Анорексия атароксическая."},
            {DiagnosisType.Type2, "Дефицит массы тела"},
            {DiagnosisType.Type3, "Норма"},
            {DiagnosisType.Type4, "избыток веса"},
            {DiagnosisType.Type5, "Ожирение 1 степени"},
            {DiagnosisType.Type6, "Ожирение 2 степени"},
            {DiagnosisType.Type7, "Ожирение 3 степени"},
            {DiagnosisType.Type8, "Ожирение 4 степени"},
        };

        private static IReadOnlyDictionary<DiagnosisType, string> RiskByDiagnosisKey = new Dictionary<DiagnosisType, string> {
            {DiagnosisType.Type1, "Высокий"},
            {DiagnosisType.Type2, "Отсутствует"},
            {DiagnosisType.Type3, "Отсутствует"},
            {DiagnosisType.Type4, "Повышенный"},
            {DiagnosisType.Type5, "Повышенный"},
            {DiagnosisType.Type6, "Высокий"},
            {DiagnosisType.Type7, "Очень высокий"},
            {DiagnosisType.Type8, "Чрезвычайно высокий"},
        };

        private static IReadOnlyDictionary<DiagnosisType, string> TherapyByDiagnosisKey = new Dictionary<DiagnosisType, string> {
            {DiagnosisType.Type1, "Повышение веса лечение анорексии"},
            {DiagnosisType.Type2, "Покушать чего-нибудь :)"},
            {DiagnosisType.Type3, "Похудения не требуется"},
            {DiagnosisType.Type4, "Рекомендуется похудение"},
            {DiagnosisType.Type5, "Рекомендуется снижение массы тела"},
            {DiagnosisType.Type6, "Настоятельно рекомендуется снижение массы тела"},
            {DiagnosisType.Type7, "Настоятельно рекомендуется снижение массы тела"},
            {DiagnosisType.Type8, "Необходимо немедленное снижение массы тела"},
        };

        private static IReadOnlyDictionary<Func<double, bool>, DiagnosisType> DiagnosesTypeByCondition = new Dictionary<Func<double, bool>, DiagnosisType> {
            {x => x < 17.5, DiagnosisType.Type1},
            {x => x < 18.5, DiagnosisType.Type2},
            {x => x < 25.9, DiagnosisType.Type3},
            {x => x < 27.9, DiagnosisType.Type4},
            {x => x < 30.9, DiagnosisType.Type5},
            {x => x < 35.9, DiagnosisType.Type6},
            {x => x < 40.9, DiagnosisType.Type7},
            {x => x > 40.9, DiagnosisType.Type8},
        };

        private static TaskReturnCode ExecuteTask5Solution()
        {
            //5.а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
            //массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

            Console.WriteLine("Программа рассчета индекса массы тела (для людей, старше 25 лет).");

            double PersonWeight = ConsoleHelper.ReadInputUntillCorrect("Введите ваш вес (кг):", ConsoleHelper.ReadAnyPositiveNumber);
            double PersonHeight = ConsoleHelper.ReadInputUntillCorrect("Введите ваш рост (см):", ConsoleHelper.ReadAnyPositiveNumber);

            double BMI = CalculateBMI(PersonWeight, PersonHeight);

            var Results = GetDiagnosesResultsForBMI(BMI);
            string DiagnosisText = Results.Item1;
            string RiskText = Results.Item2;
            string TherapyText = Results.Item3;

            double IdealWeight = CalculateIdealWeight(PersonHeight);
            double WeightDiff = IdealWeight - PersonWeight;
            string WeightRecommendation = WeightDiff > 0 ? "набрать" : "сбросить";

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Результаты расчета");
            Console.ResetColor();
            Console.WriteLine($"ИМТ: {BMI}");
            Console.WriteLine($"Состояние здоровья: {DiagnosisText}");
            Console.WriteLine($"Риск для здоровья: {RiskText}");
            Console.WriteLine($"Что делать: {TherapyText}");
            Console.WriteLine($"Идеальная масса для вашего роста: {IdealWeight}");
            Console.WriteLine($"Для достижения идеальной массы нужно {WeightRecommendation}: {Math.Abs(WeightDiff):F2}");
            Console.ReadKey();

            return TaskReturnCode.Continue;
        }

        private static Tuple<string, string, string> GetDiagnosesResultsForBMI(double BMI)
        {
            string DiagnosisText = "";
            string RiskText = "";
            string TherapyText = "";

            foreach (var item in DiagnosesTypeByCondition)
            {
                if (item.Key(BMI))
                {
                    DiagnosisType DiagnosisType = item.Value;
                    DiagnosisText = DiagnosisByDiagnosisKey[DiagnosisType];
                    RiskText = RiskByDiagnosisKey[DiagnosisType];
                    TherapyText = TherapyByDiagnosisKey[DiagnosisType];

                    break;
                }
            }

            return new Tuple<string, string, string>(DiagnosisText, RiskText, TherapyText);
        }

        private static double CalculateBMI(double personWeight, double personHeight)
        {
            personHeight = personHeight / 100;

            // BMI = m / h^2; m - kilogram, h - in meters
            return personWeight / (personHeight * personHeight);
        }

        private static double CalculateIdealWeight(double personHeight)
        {
            // Mohhamed formula
            return personHeight * personHeight * 0.00225;
        }
    }
}
