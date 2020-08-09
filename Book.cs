using System;
using System.Collections.Generic;
namespace GradeBook{
    public class Book {
        private List<double> grades;
        public string Name;
        public Book(string name){
            grades= new List<double>();
            Name= name;
        }
        public void AddGrade(double grade){
            if (grade<=100 && grade >=0){
               grades.Add(grade);
            }
            else {
                System.Console.WriteLine("Invalid Value!");
            }
            
        }
        public Statistics GetStatistics()
        {
        var result = new Statistics();    
         result.Average=0.0;
         result.High= double.MinValue;
         result.Low= double.MaxValue;
        foreach(var garde in grades)
        {
           result.Low= Math.Min(garde,result.Low);
           result.High= Math.Max(garde,result.High);
           result.Average+= garde;
        }
        result.Average/=grades.Count;
         return result;
        }
    }
}