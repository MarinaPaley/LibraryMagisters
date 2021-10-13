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
        public Book(Guid id, string title)
        {
            Id = id;
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

        public override string ToString() =>
               $"{this.Title} {this.Authors.Join(",")}".Trim();
    }
}
