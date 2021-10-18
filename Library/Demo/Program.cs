// <copyright file="Program.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Demo
{
    using System;
    using Domain;
    using ORM;

    /// <summary>
    /// Точка входа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        private static void Main()
        {
            var shelf = new Shelf(Guid.NewGuid(), "Верхняя полка");

            var author = new Author(Guid.NewGuid(), "Толстой", "Алексей", "Николаевич");

            var book1 = new Book(Guid.NewGuid(), "Приключения Буратино", author);
            var book2 = new Book(Guid.NewGuid(), "Гиперболоид инженера Гарина", author);
            var book3 = new Book(Guid.NewGuid(), "Аэлита", author);

            book1.PutToShelf(shelf);

            var sessionFactory = NHibernateConfigurator.GetSessionFactory(showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                // session.Save(book1);
                //session.Save(book2);
                session.Save(book3);
                session.Flush();
            }

            Console.WriteLine($"Книга: {book1}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Полка: {shelf}");
        }
    }
}
