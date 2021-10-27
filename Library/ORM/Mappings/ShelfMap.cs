// <copyright file="ShelfMap.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Shelf"/> на таблицу в БД и наоборот.
    /// </summary>
    internal class ShelfMap : ClassMap<Shelf>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ShelfMap"/>.
        /// </summary>
        public ShelfMap()
        {
            // this.Schema("Domain");
            this.Table("Shelves");

            this.Id(x => x.Id).GeneratedBy.Guid();

            this.Map(x => x.Name).Not.Nullable();

            this.HasMany(x => x.Books).Inverse();
        }
    }
}
