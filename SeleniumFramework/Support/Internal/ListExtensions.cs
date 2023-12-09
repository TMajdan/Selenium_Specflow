namespace SeleniumFramework.Src.Support.Extensions.Internal
{
    using System.Collections.Generic;

    internal static class ListExtensions
    {
        public static string ListToString<T>(this IEnumerable<T> list, string separator = ", ")
        {
            return string.Join(separator, list);
        }
    }
}