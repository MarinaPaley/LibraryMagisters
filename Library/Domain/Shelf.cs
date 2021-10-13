namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Полка.
    /// </summary>
    public class Shelf
    {
        public Shelf(Guid id, string name)
        {
            this.Id = id;
            this.Name = name.TrimOrNull() ??
                throw new ArgumentOutOfRangeException(nameof(name));
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Полка.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Список книг.
        /// </summary>
        public ISet<Book> Books { get; protected set; } 
            = new HashSet<Book>();

        public override string ToString()
        {
            return $"{this.Name} {Books.Join(",")}".Trim();
        }
    }
}
