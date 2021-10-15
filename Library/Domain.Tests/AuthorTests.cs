// <copyright file="AuthorTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="Author"/>.
    /// </summary>
    [TestFixture]
    public class AuthorTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var author = new Author(Guid.NewGuid(), "Толстой", "Алексей", "Николаевич");

            // act
            var result = author.ToString();

            // assert
            Assert.AreEqual("Толстой А. Н.", result);
        }

        [Test]
        public void Equals_ValidData_Success()
        {
            // arrange
            var author = new Author(Guid.NewGuid(), "Толстой", "Алексей", "Николаевич");

            // act
            var result = author.Equals(author);

            // assert
            Assert.IsTrue(result);
        }
    }
}
