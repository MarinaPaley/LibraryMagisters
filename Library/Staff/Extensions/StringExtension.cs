﻿namespace Staff.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static string TrimOrNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty() ? null : trimmed;
        }
    }
}
