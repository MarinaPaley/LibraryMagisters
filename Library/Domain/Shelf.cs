// <copyright file="Shelf.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Полка.
    /// </summary>
    public class Shelf : BaseEntity<Shelf>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        /// <param name="name"> Название полки. </param>
        public Shelf(string name)
        {
            this.Name = name.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(name));
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Shelf()
        {
        }

        /// <summary>
        /// Полка.
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Список книг.
        /// </summary>
        public virtual ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        /// <inheritdoc/>
        public override string ToString()
        {
            var separator = $"{Environment.NewLine}\t";
            return $"{this.Name}:{separator}{this.Books.Join(separator)}".Trim();
        }
    }
}
