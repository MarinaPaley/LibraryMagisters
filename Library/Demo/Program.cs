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
            var id3 = Guid.NewGuid();
            var shelf = new Shelf(id3, "Верхняя полка");

            var id2 = Guid.NewGuid();
            var author = new Author(id2, "Толстой", "Алексей", "Николаевич");

            var id1 = Guid.NewGuid();
            var book = new Book(id1, "Приключения Буратино", author);

            book.PutToShelf(shelf);

            Console.WriteLine(book);
            Console.WriteLine(author);
            Console.WriteLine(shelf);
        }
    }
}
