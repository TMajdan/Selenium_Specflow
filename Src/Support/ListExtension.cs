namespace Task_TMajdan.Src.Support
{
    using System.Collections.Generic;
    public static class ListExtension
    {
          public static string ListToString<T>(this IEnumerable<T> list, string separator = ", ")
        {
            return string.Join(separator, list);
        }
    }
}