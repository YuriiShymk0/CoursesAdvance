using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start position element on array ");
            foreach (var number in IntArr.ArrInt)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n\nSum of last figure in number from array: " + SumOfSecondPartOfNumbers());
            var arr = OPerationWithSecondPartOfNumbers(out int MaxElement);
            Console.WriteLine("\nSorted array by last figure in numbers from array ");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n\nMax element in array= " + MaxElement);

            AddNewAbiturients(20);

            foreach (var school in AllSchoolsYears())
            {
                Console.WriteLine("\nSchool = {0}: ", school.Key);
                foreach (var year in school.Value)
                {
                    Console.WriteLine(string.Format("\t\t{0}", year));
                }
            }
        }

        private static int SumOfSecondPartOfNumbers()
        {
            return IntArr.ArrInt.Select(num => num % 10).Sum();
        }

        private static List<int> OPerationWithSecondPartOfNumbers(out int MaxElement)
        {
            List<int> sortedByLastNumber = IntArr.ArrInt.OrderBy(n => n % 10).ToList();
            MaxElement = sortedByLastNumber.Max();
            return sortedByLastNumber;
        }

        private static readonly List<string> surnames = new List<string>
        {
            "Maximov",
            "Ivanov",
            "Mukolenko",
            "Gasiev"
        };

        private static readonly List<int> schoolNumbers = new List<int>
        {
           100,
           101,
           102,
           103,
           104
        };

        private static Dictionary<int, List<int>> AllSchoolsYears()
        {
            Dictionary<int, List<int>> schoolsYears = new Dictionary<int, List<int>>();
            foreach (var schoolNumber in schoolNumbers)
            {
                schoolsYears.Add(schoolNumber, AllYearOfEnteredToSchool(schoolNumber));
            }
            return schoolsYears;
        }


        private static List<int> AllYearOfEnteredToSchool(int NumberOfSchool)
        {

            List<int> AllYearOfEnteredToSchool = _abiturients.Where(a => a.SchoolNumber == NumberOfSchool)
                                                             .GroupBy(abit => abit.YearOfEntry)
                                                             .Select(abitur => abitur.Key)
                                                             .OrderBy(abiturs => abiturs)
                                                             .ToList();
            return AllYearOfEnteredToSchool;
        }

        private static List<Abiturient> _abiturients = new List<Abiturient>(10);
        private static List<Abiturient> AddNewAbiturients(int numberOfAbiturients = 50)
        {
            Random rand = new Random();
            for (int i = 0; i < numberOfAbiturients; i++)
            {
                Abiturient abiturient = new Abiturient()
                {
                    Surname = surnames[rand.Next(surnames.Count)],
                    SchoolNumber = rand.Next(100, 105),
                    YearOfEntry = rand.Next(DateTime.Now.Year - 20, DateTime.Now.Year)
                };
                _abiturients.Add(abiturient);
            }
            return _abiturients;
        }
    }
}
