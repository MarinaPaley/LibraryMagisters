// <copyright file="Program.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Demo
{
    using System;
    using Domain;

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

            var book = new Book(Guid.NewGuid(), "Приключения Буратино", author);

            book.PutToShelf(shelf);

            Console.WriteLine($"Книга: {book}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Полка: {shelf}");
        }
    }
}
