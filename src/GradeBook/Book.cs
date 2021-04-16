using System;
using System.Collections.Generic;

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
    public class Book : NamedObject
    {
        //before using an object we must init this in constructor , statment new...() is simply running an constructor 
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
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
        public event GradeAddedDelegate GradeAdded;
        public Statistics GetStatistics()
        {   
            var result = new Statistics();
            result.Avarage = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            //for every value <number> in arr numbers. it has to have a type correct
            
            for(var i =0; i<grades.Count; i++)
            {
                // if (grades[i]==42.1)
                // {
                //     break;
                //     continue ->skip next 3 lines but keeps iterating in the loop
                //     goto done; -> go to done: 
                // }
                result.High = Math.Max(grades[i],result.High);
                result.Low = Math.Min(grades[i],result.Low);
                result.Avarage =result.Avarage + grades[i];
            }
            result.Avarage=result.Avarage/grades.Count;
            // done:
            switch(result.Avarage)
            {
                case var d when d>=90:
                    result.Letter ='A';
                    break;
                case var d when (80 <= d && d < 89):
                    result.Letter ='B';
                    break;
                case var d when (70 <= d && d < 79):
                    result.Letter ='C';
                    break;
                case var d when (60 <= d && d < 69):
                    result.Letter ='D';
                    break;
                case var d when (50 <= d && d < 59):
                    result.Letter ='E';
                    break;
                default:
                    result.Letter = 'F';
                    break;


            }
            return result;
        }
        List<double> grades;
       
        public const string CATEGORY = "Science";
        //readonly can be changed only in constructor
        //const can not be modyfiyng, if we use public const name of variable schould be uppercases
    }
}