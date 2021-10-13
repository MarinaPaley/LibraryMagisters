namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
        [Obsolete("For ORM only", true)]
        protected Author()
        {
        }

        public Author(Guid id, string familyName, string firstName, string middleName = null)
        {
            this.Id = id;

            this.FamilyName = familyName.TrimOrNull() ??
               throw new ArgumentOutOfRangeException(nameof(familyName));

            this.FirstName = firstName.TrimOrNull() ??
                throw new ArgumentOutOfRangeException(nameof(firstName));

            this.MiddleName = middleName.TrimOrNull();
        }

        public bool AddBook(Book book)
        {
            return book == null
                ? throw new ArgumentNullException(nameof(book))
                : this.Books.Add(book);
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FamilyName { get; protected set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; protected set; }

        /// <summary>
        /// Полное Имя.
        /// </summary>
        public string FullName => $"{FamilyName} {FirstName[0]}. {MiddleName?[0]}.".Trim();

        public override string ToString() => this.FullName;

        public ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        public override bool Equals(object obj)
        {
            return obj is not null && (ReferenceEquals(this, obj) || Equals((Author) obj));
        }

        public bool Equals(Author other)
        {
            return other is not null && (ReferenceEquals(this, other) || this.Id == other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
