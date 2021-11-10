// <copyright file="ShelfMapTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>
namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Модульные тесты для класса <see cref="ShelfMap"/>.
    /// </summary>
    [TestFixture]
    internal class ShelfMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var shelf = new Shelf("Тестовая полка");

            // act & assert
            new PersistenceSpecification<Shelf>(this.Session)
                .VerifyTheMappings(shelf);
        }
    }
}