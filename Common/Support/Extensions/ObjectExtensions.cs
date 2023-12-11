namespace SeleniumFramework.Src.Support.Internal
{
    using System;
    using System.Linq;

    internal static class ObjectExtensions
    {
        public static void IgnoringFailure(
         Action action,
         params Type[] exceptions)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e) when (exceptions.Length > 0 ? exceptions.Contains(e.GetType()) : typeof(Exception).IsAssignableFrom(e.GetType()))
            {
                throw new Exception($"Ignoring failure: {e.Message}");
            }
        }

    }
}