namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AuthorTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            //arrange
            var author = new Author(Guid.NewGuid(), "Толстой", "Алексей", "Николаевич");

            //act
            var result = author.ToString();

            //assert
            Assert.AreEqual("Толстой А. Н.", result);
        }

        [Test]
        public void Equals_ValidData_Success()
        {
            //arrange
            var author = new Author(Guid.NewGuid(), "Толстой", "Алексей", "Николаевич");

            //act
            var result = author.Equals(author);

            //assert
            Assert.IsTrue(result);
        }
    }
}
