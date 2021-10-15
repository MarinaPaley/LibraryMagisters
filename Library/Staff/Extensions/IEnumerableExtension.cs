// <copyright file="IEnumerableExtension.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace Staff.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public static class EnumerableExtension
    {
        public static string Join<T>(this IEnumerable<T> collection, string separator) => string.Join(separator, collection);
    }
}
