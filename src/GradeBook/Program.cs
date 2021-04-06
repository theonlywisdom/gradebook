using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {
            IBook book = new DiskBook("Wisdom's Grade Book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();

            //Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For the book name {book.Name}\n" +
                $"The average grade is {stats.Average:N2}\n" +
                $"The highest grade is {stats.High:N2}\n" +
                $"The lowest grade is {stats.Low:N2}\n" +
                $"The Letter grade is {stats.Letter}");

            //var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            //grades.Add(56.1);


        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.Write("Please enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();

                // Bug: pressing 'q' and enter with nothing else produces and average
                // of NaN
                if (input.ToLower() == "q")
                {
                    break;
                }
                else if (double.TryParse(input, out double grade))
                {
                    try
                    {
                        book.AddGrade(grade);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine($"{grade} is invalid. Please enter a valid grade.");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    }
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
