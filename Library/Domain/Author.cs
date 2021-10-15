// <copyright file="Author.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

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
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="familyName"> Фамилия. </param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="middleName"> Отчество. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В случае если <paramref name="familyName"/> или <paramref name="firstName"/> являются <br/>
        ///   - пустой строкой (<see cref="string.Empty"/>), <br/>
        ///   - строкой, состоящей только из пробельных символов <br/>
        ///   - или <see langword="null"/>.
        /// </exception>
        public Author(Guid id, string familyName, string firstName, string middleName = null)
        {
            this.Id = id;

            this.FamilyName = familyName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(familyName));

            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));

            this.MiddleName = middleName.TrimOrNull();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Author()
        {
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
        /// Полное имя.
        /// </summary>
        public string FullName => $"{this.FamilyName} {this.FirstName[0]}. {this.MiddleName?[0]}.".Trim();

        /// <summary>
        /// Книги.
        /// </summary>
        public ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        public bool AddBook(Book book)
        {
            return book == null
                ? throw new ArgumentNullException(nameof(book))
                : this.Books.Add(book);
        }

        /// <inheritdoc/>
        public override string ToString() => this.FullName;

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is not null && (ReferenceEquals(this, obj) || this.Equals((Author)obj));
        }

        /// <inheritdoc cref="IEquatable{T}"/>
        public bool Equals(Author other)
        {
            return other is not null && (ReferenceEquals(this, other) || this.Id == other.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
