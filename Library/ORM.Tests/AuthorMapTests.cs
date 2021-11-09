// <copyright file="AuthorMapTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Domain.Author"/> на таблицу в БД и наоборот.
    /// </summary>
    [TestFixture]
    internal class AuthorMapTests : BaseMap
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var author = new Author("Тестовый", "Автор");

            // act & assert
            new PersistenceSpecification<Author>(this.Session)
                .VerifyTheMappings(author);
        }
    }
}
