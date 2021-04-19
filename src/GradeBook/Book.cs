using System;
using System.Collections.Generic;
using System.IO;

namespace src.GradeBook
{
    public delegate void GradeAddedDelegate(object sender,EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;

    }
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade (double grade);

        public abstract Statistics GetStatistics();
        
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {   
            
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

        }

        public override Statistics GetStatistics()
        {   
            var result = new Statistics();  
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            
            return result;
        }
    }
    public class InMemoryBook : Book
    {
        //before using an object we must init this in constructor , statment new...() is simply running an constructor 
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {   
                grades.Add(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid grade {nameof(grade)}");
            }
            
        }
        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {   
            var result = new Statistics();
            
            //for every value <number> in arr numbers. it has to have a type correct
            
            for(var i =0; i<grades.Count; i++)
            {
                // if (grades[i]==42.1)
                // {
                //     break;
                //     continue ->skip next 3 lines but keeps iterating in the loop
                //     goto done; -> go to done: 
                // }
                result.Add(grades[i]);
                
                
            }
            return result;
        }
        List<double> grades;
       
        public const string CATEGORY = "Science";
        //readonly can be changed only in constructor
        //const can not be modyfiyng, if we use public const name of variable schould be uppercases
    }
}