using System;
using System.Collections.Generic;
namespace GradeBook
{
  class Program
    {
        static void Main(string[] args)
        {
         IBook book = new DiskBook("Student GradeBook");
         book.GradeAdded +=OnGradeAdded;
         EnterGrades(book);
         var stats=book.GetStatistics();
         System.Console.WriteLine($"The Category is {InMemoryBook.CATEGORY}");
         Console.WriteLine($"The Book Name is {book.Name}");
         Console.WriteLine($"The lowest grade is {stats.Low}");
         Console.WriteLine($"The highest grade is {stats.High}");
         Console.WriteLine($"The Average is {stats.Average:N3}");
         Console.WriteLine($"The Letter Grade is {stats.letter}");
        }
        static void OnGradeAdded(object sender, EventArgs e){
               Console.WriteLine("A grade was added!");
        }
        private static void EnterGrades (IBook book){
         var done = false;        
         while (!done){
         Console.WriteLine("Enter a grade or 'q' to quit");   
         var input = Console.ReadLine();
         if (input=="q"){
             done = true;
             continue;
         }
         try{
         var grade = double.Parse(input);
         book.AddGrade(grade);   
        }    
         catch(ArgumentException ex){
          Console.WriteLine(ex.Message);   
         }
         catch(FormatException ex){
          Console.WriteLine(ex.Message);   
         }
         }
      }  
    }
}