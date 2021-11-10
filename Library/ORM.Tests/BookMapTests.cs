// <copyright file="BookMapTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>
namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Модульные тесты для класса <see cref="BookMap"/>.
    /// </summary>
    [TestFixture]
    internal class BookMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var book = new Book("Тестовая книга");

            // act & assert
            new PersistenceSpecification<Book>(this.Session)
                .VerifyTheMappings(book);
        }
    }
}
