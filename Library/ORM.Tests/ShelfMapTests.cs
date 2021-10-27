// <copyright file="ShelfMapTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Модульные тесты для класса <see cref="ShelfMap"/>.
    /// </summary>
    public class ShelfMapTests
    {
        private ISessionFactory sessionFactory;

        private ISession session;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            this.sessionFactory = NHibernateConfigurator.GetSessionFactory(showSql: true);
        }

        [OneTimeTearDown]
        public void Terminate()
        {
            this.sessionFactory?.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            this.session = this.sessionFactory.OpenSession();
        }

        [TearDown]
        public void TearDown()
        {
            this.session?.Dispose();
        }

        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var shelf = new Shelf("Тестовая полка");

            // act & assert
            new PersistenceSpecification<Shelf>(this.session)
                .VerifyTheMappings(shelf);
        }
    }
}