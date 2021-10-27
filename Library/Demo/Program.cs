// <copyright file="Program.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Demo
{
    using System;
    using System.Linq;
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
            var shelf = new Shelf("Верхняя полка");

            var author = new Author("Толстой", "Алексей", "Николаевич");

            var book1 = new Book("Приключения Буратино", author);
            var book2 = new Book("Гиперболоид инженера Гарина", author);
            var book3 = new Book("Аэлита", author);

            book1.PutToShelf(shelf);

            var sessionFactory = NHibernateConfigurator.GetSessionFactory(showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(book1);

                session.Save(book2);
                session.Save(book3);

                session.Save(author);

                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Authors: ");
                Console.WriteLine("---------------");
                session.Query<Author>().ToList().ForEach(Console.WriteLine);
                Console.WriteLine("---------------");
            }

            Console.WriteLine($"Книга: {book2}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Полка: {shelf}");
        }
    }
}
