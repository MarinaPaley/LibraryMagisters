using NUnit.Framework;
using System;

namespace Domain.Tests
{
    public class BookTest
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            //arrange
            var id = new Guid();
            var book = new Book(id, "Приключения Буратино");

            //act
            var result = book.ToString();

            //assert
            Assert.AreEqual(result, "Приключения Буратино");
        }
    }
}