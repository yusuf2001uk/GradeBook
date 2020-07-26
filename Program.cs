using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

         var grades = new List<double>(){99.9,10.1,23.4} ;
         double sum = 0.0;
         double avg = 0.0; 
         foreach( double number in grades)
         {
             System.Console.WriteLine(grades);
             sum +=number;
             }
             Console.WriteLine($"the Sum is {sum}");
             avg/= grades.Count;
         System.Console.WriteLine($"The Average is {avg}");
        }
    }
}
