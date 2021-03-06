// <copyright file="ShelfTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="Shelf"/>.
    /// </summary>
    [TestFixture]
    public class ShelfTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var shelf = new Shelf("Полка");

            var author = new Author("Толстой", "Алексей", "Николаевич");

            var book = new Book("Приключения Буратино", author);

            book.PutToShelf(shelf);

            // act
            var result = shelf.ToString();

            // assert
            Assert.AreEqual($"Полка:{Environment.NewLine}\tТолстой А. Н. Приключения Буратино", result);
        }
    }
}
