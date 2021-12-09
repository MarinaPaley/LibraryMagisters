// <copyright file="BookRepoTests.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using NUnit.Framework;
    using ORM.Repositories;

    [TestFixture]
    internal class BookRepoTests : BaseMapTests
    {
        [Test]
        public void GetByTitle_ValidData_Success()
        {
            // arrange
            var repo = new BookRepository(this.Session);
            var title = "Приключения Буратино";

            var book1 = new Book(title);

            // act
            repo.Save(book1);
            var result = repo.GetByTitle(title);

            // assert
            Assert.AreEqual(title, result.Title);
        }

        public void Save_ValidData_Success()
        {
            // arrange
            var repo = new BookRepository(this.Session);
            var title = "Приключения Буратино";

            var book1 = new Book(title);

            // act & assert
            Assert.IsTrue(repo.Save(book1));
        }
    }
}
