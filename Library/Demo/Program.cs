namespace Demo
{
    using System;
    using Domain;
   /// <summary>
   /// 
   /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {
            var id3 = new Guid();
            var shelf = new Shelf(id3, "Верхняя полка");

            var id1 = new Guid();
            var book = new Book(id1, "Приключения Буратино", shelf);

            var id2 = new Guid();
            var author = new Author(id2, "Толстой", "Алексей", "Николаевич");

            shelf.Books.Add(book);

            book.Authors.Add(author);
            //author.Books.Add(book);
          

            Console.WriteLine(book);
            Console.WriteLine(author);
            Console.WriteLine(shelf);
        }
    }
}
