using System;
using src.GradeBook;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculateAnAverageGrade()
        {
            //atange
            var book = new Book("");
            book.AddGrade(90);
            book.AddGrade(4);
            book.AddGrade(23);
           
            //act
            var result = book.GetStatistics();
            //assert
            Assert.Equal(39, result.Avarage, 1);
            Assert.Equal(90,result.High, 1);
            Assert.Equal(4,result.Low, 1);
            Assert.Equal('F',result.Letter);
        }
    }
}
