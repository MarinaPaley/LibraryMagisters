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
    public class Shelf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Shelf()
        {
        }

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
        public ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        public override string ToString()
        {
            var separator = $"{Environment.NewLine}\t";
            return $"{this.Name}:{separator}{Books.Join(separator)}".Trim();
        }
    }
}
