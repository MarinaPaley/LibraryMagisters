// <copyright file="BaseEntity.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>
namespace Domain
{
    using System;

    /// <summary>
    /// Базовая сущность.
    /// </summary>
    /// <typeparam name="T"> Сущность. </typeparam>
    public abstract class BaseEntity<T> where T : BaseEntity<T>
    {
        /// <summary>
        /// Хеш-код идентификатора для persistent объекта.
        /// </summary>
        private int? oldHashCode;

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        public static bool operator ==(BaseEntity<T> lhs, BaseEntity<T> rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(BaseEntity<T> lhs, BaseEntity<T> rhs)
        {
            return !Equals(lhs, rhs);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (obj is not T other)
            {
                return false;
            }

            var thisIsNew = Equals(this.Id, Guid.Empty);
            var otherIsNew = Equals(other.Id, Guid.Empty);

            if (thisIsNew && otherIsNew)
            {
                return ReferenceEquals(this, other);
            }

            return this.Id.Equals(other.Id);
        }

     /// <inheritdoc/>
        public override int GetHashCode()
        {
            if (this.oldHashCode.HasValue)
            {
                return this.oldHashCode.Value;
            }

            var thisIsNew = Equals(this.Id, Guid.Empty);
            if (!thisIsNew)
            {
                return this.Id.GetHashCode();
            }

            this.oldHashCode = base.GetHashCode();
            return this.oldHashCode.Value;
        }
    }
}
