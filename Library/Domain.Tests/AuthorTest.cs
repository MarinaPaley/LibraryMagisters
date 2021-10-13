namespace Domain.Tests
{
    using NUnit.Framework;
    using System;
    class AuthorTest
    {
        [Test]
        public void ToString_ValidData_Success() 
        {
            //arrange
            var id1 = new Guid();
            var shelf = new Shelf(id1, "Полка");
            var id = new Guid();
            var author = new Author(id, "Толстой", "Алексей", "Николаевич");
            var id2 = new Guid();
            var book = new Book(id2, "Приключения Буратино", shelf);
            author.Books.Add(book);

            //act
            var result = author.ToString();

            //assert
            Assert.AreEqual("Толстой А. Н. Приключения Буратино", result);
        }

        [Test]
        public void Equals_ValidData_Success()
        {
            //arrange
            var id = new Guid();
            var author = new Author(id, "Толстой", "Алексей", "Николаевич");

            //act
            var result = author.Equals(author);

            //assert
            Assert.AreEqual(true, result);
        }
    }
}
