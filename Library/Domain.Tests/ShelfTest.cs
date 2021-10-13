namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    
    public class ShelfTest
    {
        [Test]
        public void Shelf_ToString_Success()
        {
            //arrange
            var id = new Guid();
            var book = new Book(id, "Приключения Буратино");
            var id1 = new Guid();
            var shelf = new Shelf(id1, "Полка");
            shelf.Books.Add(book);

            //act
            var result = shelf.ToString();

            //assert
            Assert.AreEqual("Полка Приключения Буратино", result);
        }
    }
}
