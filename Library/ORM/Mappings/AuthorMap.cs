// <copyright file="AuthorMap.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Author"/> на таблицу в БД и наоборот.
    /// </summary>
    internal class AuthorMap : ClassMap<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthorMap"/>.
        /// </summary>
        public AuthorMap()
        {
                // this.Schema("Domain");
                this.Table("Authors");

                this.Id(x => x.Id).GeneratedBy.Guid();

                this.Map(x => x.FamilyName).Not.Nullable();
                this.Map(x => x.FirstName).Not.Nullable();
                this.Map(x => x.MiddleName);

                this.HasManyToMany(x => x.Books);
        }
    }
}
