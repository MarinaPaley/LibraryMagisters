// <copyright file="AuthorTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using NHibernate;
    using NUnit.Framework;

    /// <summary>
    /// Базовый класс для тестирования маппингов.
    /// </summary>
    public class BaseMap
    {
        protected ISessionFactory SessionFactory { get; private set; }

        protected ISession Session { get; private set; }

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            this.SessionFactory = NHibernateConfigurator.GetSessionFactory(showSql: true);
        }

        [OneTimeTearDown]
        public void Terminate()
        {
            this.SessionFactory?.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            this.Session = this.SessionFactory.OpenSession();
        }

        [TearDown]
        public void TearDown()
        {
            this.Session?.Dispose();
        }
    }
}