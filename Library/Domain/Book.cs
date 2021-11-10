// <copyright file="Book.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

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
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title"> Название. </param>
        /// <param name="authors"> Коллектив авторов. </param>
        public Book(string title, params Author[] authors)
            : this(title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title"> Название. </param>
        /// <param name="authors"> Коллектив авторов. </param>
        public Book(string title, ISet<Author> authors = null)
        {
            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    this.Authors.Add(author);
                    author.AddBook(this);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Book()
        {
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public virtual string Title { get; protected set; }

        /// <summary>
        /// Список авторов данной книги.
        /// </summary>
        public virtual ISet<Author> Authors { get; protected set; } = new HashSet<Author>();

        /// <summary>
        /// Полка, на которой стоит книга.
        /// </summary>
        // TODO: Должна ли книга знать о полке, на которой она стоит?
        public virtual Shelf Shelf { get; protected set; }

        /// <summary>
        /// Ставит данную книгу на полку <paramref name="shelf"/>.
        /// </summary>
        /// <param name="shelf"> Целевая полка. </param>
        public virtual void PutToShelf(Shelf shelf)
        {
            this.Shelf?.Books.Remove(this);

            this.Shelf = shelf ?? throw new ArgumentNullException(nameof(shelf));

            this.Shelf?.Books.Add(this);
        }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Authors.Join(", ")} {this.Title}".Trim();
    }
}
