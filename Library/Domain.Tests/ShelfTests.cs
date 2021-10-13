namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ShelfTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            //arrange
            var shelf = new Shelf(Guid.NewGuid(), "Полка");

            var author = new Author(Guid.NewGuid(), "Толстой", "Алексей", "Николаевич");

            var book = new Book(Guid.NewGuid(), "Приключения Буратино", author);

            book.PutToShelf(shelf);

            //act
            var result = shelf.ToString();

            //assert
            Assert.AreEqual($"Полка:{Environment.NewLine}\tТолстой А. Н. Приключения Буратино", result);
        }
    }
}
