// <copyright file="EnumerableExtension.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Staff.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// Коллекция методов расширения для интерфейса <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtension
    {
        public static string Join<T>(this IEnumerable<T> collection, string separator) => string.Join(separator, collection);
    }
}
