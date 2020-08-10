using System;
using System.Collections.Generic;
namespace GradeBook
{
       class Program
    {
        static void Main(string[] args)
        {
         Book book = new Book("Yusuf GradeBook");
         book.AddGrade(89.1);
         book.AddGrade(90.5);
         book.AddGrade(77.5);
         
        var stats=book.GetStatistics();

        Console.WriteLine($"The lowest grade is {stats.Low}");
        Console.WriteLine($"The highest grade is {stats.High}");
        Console.WriteLine($"The Average is {stats.Average:N3}");
        Console.WriteLine($"The Letter Grade is {stats.letter}");
        }
    }
}
