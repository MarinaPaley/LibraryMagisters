namespace Domain.Tests
{
    using NUnit.Framework;
    using System;
    public class BookTest
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            //arrange
            var id1 = new Guid();
            var shelf = new Shelf(id1, "Полка");
            var id = new Guid();
            var book = new Book(id, "Приключения Буратино", shelf);
            var id2 = new Guid();
            var author = new Author(id2, "Толстой", "Алексей", "Николаевич");
            book.Authors.Add(author);

            //act
            var result = book.ToString();

            //assert
            Assert.AreEqual(result, "Приключения Буратино Толстой А. Н.");
        }

        [Test]
        public void Equals_ValidData_Success()
        {
            //arrange
            var id1 = new Guid();
            var shelf = new Shelf(id1, "Полка");
            var id = new Guid();
            var book = new Book(id, "Приключения Буратино", shelf);

            //act
            var result = book.Equals(book);

            //assert
            Assert.AreEqual(true, result);
        }
    }
}