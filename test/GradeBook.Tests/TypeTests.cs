using System;
using src.GradeBook;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTest
    {
        [Fact]
        public void WriteLogDelegateCanPointMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            var result = log("hello");
            Assert.Equal("hello", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
           
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(ref book1,"New Name");

            Assert.Equal("New Name",book1.Name);
        }

        private void GetBookSetName( ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        
        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(book1,"New Name");

            Assert.Equal("Book1",book1.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1,"New Name");

            Assert.Equal("New Name",book1.Name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }
        [Fact]
        public void StringsBehaveLikeValue()
        {
            string name = "Scott";
            var upper = MakeUppercase(name);
            Assert.Equal("Scott",name);
            Assert.Equal("SCOTT",upper);
        }

        private string MakeUppercase(string param)
        {
             return param.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObject()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1,book2);

        }
         [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
