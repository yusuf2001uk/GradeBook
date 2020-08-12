using System;
using System.Collections.Generic;
namespace GradeBook{
    public class Book {
        private List<double> grades;
        public string name;
        public string Name
        {
           get
           {
               return name;
           }
           set {
               if (!String.IsNullOrEmpty(value)){
                   name=value;
               }
           }
        }
        public const string CATEGORY="Science";
        public Book(string name){
            grades= new List<double>();
            Name= name;
        }
        public void AddGrade(char letter){
        switch(letter){
            case 'A':
            AddGrade(90);
            break;
            case 'B':
            AddGrade(80);
            break;
            case 'c':
            AddGrade(70);
            break;
            default:
            AddGrade(0);
            break;
        }
        }
        public void AddGrade(double grade){
            if (grade<=100 && grade >=0){
               grades.Add(grade);
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public Statistics GetStatistics()
        {
        var result = new Statistics();    
         result.Average=0.0;
         result.High= double.MinValue;
         result.Low= double.MaxValue;
        var index=0;
        while (index < grades.Count)
        {
           result.Low= Math.Min(grades[index],result.Low);
           result.High= Math.Max(grades[index],result.High);
           result.Average+= grades[index];
           index +=1;
        }
        result.Average/=grades.Count;
        switch(result.Average)
        {
            case var d when d >= 90.0:
            result.letter= 'A';
            break;
            
            case var d when d >= 80.0:
            result.letter= 'B';
            break;

            case var d when d >= 70.0:
            result.letter= 'C';
            break;
            
            case var d when d >= 60.0:
            result.letter= 'D';
            break;
            
            default:
            result.letter= 'F';
            break;
        }
         return result;
        }
    }
}