using System;
using System.Collections.Generic;
namespace GradeBook
{
       class Program
    {
        static void Main(string[] args)
        {
         if (true){
         var grades = new List<double>() {99.9,10.1,23.4} ;
         double sum = 0.0;
         double avg = 0.0; 
         foreach( double number in grades)
         {
             System.Console.WriteLine(number);
             sum +=number;
         }
             avg=sum/grades.Count;
             Console.WriteLine($"The Sum is {sum}");
             Console.WriteLine($"The Average is {avg:N3}");
            }
            else{
                Console.WriteLine("Error Input, Bye!");
            }
        }
    }
}
