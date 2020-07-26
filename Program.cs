using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
         
         var numbers = new [] {99.9,10.1,23.4};
         double result = 0.0;
         foreach( double number in numbers )
         {
             System.Console.WriteLine(number);
             result +=number;
             }
         System.Console.WriteLine(result);
        }
    }
}
