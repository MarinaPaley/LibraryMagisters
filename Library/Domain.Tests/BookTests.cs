namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BookTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            //arrange
            var author = new Author(Guid.NewGuid(), "Толстой", "Алексей", "Николаевич");

            var book = new Book(Guid.NewGuid(), "Приключения Буратино", author);

            //act
            var result = book.ToString();

            //assert
            Assert.AreEqual(result, "Толстой А. Н. Приключения Буратино");
        }

        [Test]
        public void Equals_ValidData_Success()
        {
            //arrange
            var book = new Book(Guid.NewGuid(), "Приключения Буратино");

            //act
            var result = book.Equals(book);

            //assert
            Assert.IsTrue(result);
        }
    }
}