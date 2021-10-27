// <copyright file="BookTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="Book"/>.
    /// </summary>
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var author = new Author("Толстой", "Алексей", "Николаевич");

            var book = new Book("Приключения Буратино", author);

            // act
            var result = book.ToString();

            // assert
            Assert.AreEqual(result, "Толстой А. Н. Приключения Буратино");
        }

        [Test]
        public void Equals_ValidData_Success()
        {
            // arrange
            var book = new Book("Приключения Буратино");

            // act
            var result = book.Equals(book);

            // assert
            Assert.IsTrue(result);
        }
    }
}