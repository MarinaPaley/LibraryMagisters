namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;
    /// <summary>
    /// Книга.
    /// </summary>
    public class Book
    {
        public Book(Guid id, string title, Shelf shelf)
        {
            Id = id;
            this.Shelf = shelf ?? throw new ArgumentNullException(nameof(shelf));
            this.Title = title.TrimOrNull()??
                throw new ArgumentOutOfRangeException(nameof(title));              
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; protected set; }

        public ISet<Author> Authors { get; protected set; } 
                = new HashSet<Author>();

        public Shelf Shelf { get; protected set; }

        public override string ToString() =>
               $"{this.Title} {this.Authors.Join(",")}".Trim();
    }
}
