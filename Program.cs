using System;
using System.Collections.Generic;
namespace GradeBook
{
  class Program
    {
        static void Main(string[] args)
        {
         Book book = new Book("Student GradeBook");
         var done = false;        
         while (!done){
         Console.WriteLine("Enter a grade or 'q' to quit");   
         var input = Console.ReadLine();
         if (input=="q"){
             done = true;
             continue;
         }
         var grade = double.Parse(input);
         book.AddGrade(grade);   
        }         
         var stats=book.GetStatistics();
         Console.WriteLine($"The lowest grade is {stats.Low}");
         Console.WriteLine($"The highest grade is {stats.High}");
         Console.WriteLine($"The Average is {stats.Average:N3}");
         Console.WriteLine($"The Letter Grade is {stats.letter}");
        }
    }
}