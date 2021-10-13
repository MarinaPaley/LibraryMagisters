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
        public Author(Guid id, string familyName, string firstName, string middleName = null)
        {
            Id = id;

            this.FamilyName = familyName.TrimOrNull() ??
               throw new ArgumentOutOfRangeException(nameof(familyName));

            this.FirstName = firstName.TrimOrNull() ??
                throw new ArgumentOutOfRangeException(nameof(firstName));

            this.MiddleName = middleName.TrimOrNull();

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
        public string FullName =>
            $"{FamilyName} {FirstName[0]}. {MiddleName?[0]}.".Trim();

        public override string ToString() 
            => $"{this.FullName} {Books.Join(",")}".Trim();

        public ISet<Book> Books { get; protected set; } = 
            new HashSet<Book>();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Author)obj);
        }

        public bool Equals(Author other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
