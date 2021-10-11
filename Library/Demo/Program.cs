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
            var id1 = new Guid();
            var book = new Book(id1, "Приключения Буратино");

            var id2 = new Guid();
            var author = new Author(id2, "Толстой", "Алексей", "Николаевич");
            Console.WriteLine(book);
            Console.WriteLine(author);
        }
    }
}
