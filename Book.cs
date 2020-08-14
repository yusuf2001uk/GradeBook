using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NamedObject{                                          //NamedObject Class
        public NamedObject(string name){
            Name = name;
        }
        public string Name
        {
           get;
           set;
        }
    }
      public interface IBook{                                             // IBook Interface
      void AddGrade(double grade);
      Statistics GetStatistics();
      string Name {get;}
      event GradeAddedDelegate GradeAdded;
   }
       public abstract class Book : NamedObject, IBook{                    //Book Class
       protected Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
    public class DiskBook : Book                                         // DiskBook Class
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
           using (var writer = File.AppendText($"{Name}.txt")){
            writer.WriteLine(grade);
            if (GradeAdded!=null){
                GradeAdded(this, new EventArgs());
            }
           }
            
            
        }
        public override Statistics GetStatistics()
        {
           var result =  new Statistics();
           using (var reader = File.OpenText($"{Name}.txt")){
               var line = reader.ReadLine();
               while(line != null){
                  var number = double.Parse(line);
                  result.Add(number);
                  line = reader.ReadLine();          
               }
           }
           return result;
        }
    }
    public class InMemoryBook : Book { // InMemory Class
        private List<double> grades;
        public override event GradeAddedDelegate GradeAdded;
        public const string CATEGORY="Science";
        public InMemoryBook(string name):base(name){
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
        public override void AddGrade(double grade){
            if (grade<=100 && grade >=0){
               grades.Add(grade);
               if(GradeAdded!= null){
                 GradeAdded(this, new EventArgs());  
               }
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override Statistics GetStatistics()
        {
        var result = new Statistics();    
        
        var index=0;
        while (index < grades.Count)
        {
           result.Add(grades[index]);
           index +=1;
        }
         return result;
        }
    }
}