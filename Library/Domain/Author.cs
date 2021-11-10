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
    public class Author : BaseEntity<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="familyName"> Фамилия. </param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="middleName"> Отчество. </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В случае если <paramref name="familyName"/> или <paramref name="firstName"/> являются <br/>
        ///   - пустой строкой (<see cref="string.Empty"/>), <br/>
        ///   - строкой, состоящей только из пробельных символов <br/>
        ///   - или <see langword="null"/>.
        /// </exception>
        public Author(string familyName, string firstName, string middleName = null)
        {
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
        /// Имя.
        /// </summary>
        public virtual string FirstName { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public virtual string FamilyName { get; protected set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public virtual string MiddleName { get; protected set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public virtual string FullName => $"{this.FamilyName} {this.FirstName[0]}. {this.MiddleName?[0]}.".Trim();

        /// <summary>
        /// Книги.
        /// </summary>
        public virtual ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        /// <summary>
        /// Добавляет книгу данному автору.
        /// </summary>
        /// <param name="book"> Добавляемая автору книга. </param>
        /// <returns>
        /// <see langword="true"/> если операция успешно завершена, <see langword="false"/> в противном случае.
        /// </returns>
        public virtual bool AddBook(Book book)
        {
            return book == null
                ? throw new ArgumentNullException(nameof(book))
                : this.Books.Add(book);
        }

        /// <inheritdoc/>
        public override string ToString() => this.FullName;
    }
}
