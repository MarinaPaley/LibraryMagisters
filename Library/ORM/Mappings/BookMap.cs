// <copyright file="BookMap.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Book"/> на таблицу в БД и наоборот.
    /// </summary>
    internal class BookMap : ClassMap<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BookMap"/>.
        /// </summary>
        public BookMap()
        {
            // this.Schema("Domain");
            this.Table("Books");

            this.Id(x => x.Id).GeneratedBy.Guid();

            this.Map(x => x.Title).Length(255).Not.Nullable();

            this.HasManyToMany(x => x.Authors).Inverse();

            this.References(x => x.Shelf);
        }
    }
}
