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
    public class BaseMapTests
    {
        protected ISession Session { get; private set; }


        [SetUp]
        public void SetUp()
        {
            this.Session = NHibernateTestsConfigurator.BuildSessionForTest();
        }

        [TearDown]
        public void TearDown()
        {
            this.Session?.Dispose();
        }
    }
}