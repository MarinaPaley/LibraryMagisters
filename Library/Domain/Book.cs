namespace Domain
{
    using System;
    /// <summary>
    /// Книга.
    /// </summary>
    public class Book
    {
        public Book(Guid id, string title)
        {
            Id = id;
            var trimmed = title?.Trim();
            if (string.IsNullOrEmpty(trimmed))
                throw new ArgumentNullException(nameof(title));

            Title = trimmed;                
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; protected set; }

        public override string ToString() => this.Title;
    }
}
