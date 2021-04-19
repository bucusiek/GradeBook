using System;
using System.Collections.Generic;
using src.GradeBook;

namespace GradeBook
{
    class Program
    {
      
        static void Main(string[] args)
        {
            // var x =98.2; // implicit type conversion - compilator decides what type is variable, they must be initialized
            // var numbers = new [] {12, 332.3, 343.3}; // befour using array we must initialize it in C# we can use {} after and later assign values
            //we dont have to assign length of array . compiller will do this automaticly
            //we dont have to assign a type of array 
            //ctr .  to quick fixes
            // static metod can not be used in object. we can use static i statment Program.Main(args) 
            //ctr k+c to coment bunch of code, ctrl k+u to undone + ctrl /
            var book = new DiskBook("Beauty Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            var stats = book.GetStatistics();

            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"The avarage grade is: {stats.Avarage:N1}");
            Console.WriteLine($"The heiest grade is: {stats.High}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The letter grade is: {stats.Letter}");
            //:N1 says that we have one place after digit 
            //Console.WriteLine($"Hello, {args[0]}!"); // interpolation, we can use in string other values of expression

        }

        private static void EnterGrade(IBook book)
        {
            while (true)//infinite loop
            {
                Console.WriteLine("Enter a number or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded (object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

    }       //brakepoints are used for stop debbuger in place when we were at red circle  
}
