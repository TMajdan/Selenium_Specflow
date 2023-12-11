namespace Task_TMajdan.Src.Exceptions
{
    using System;

    internal class RestClientException : Exception
    {
        public RestClientException()
        {
        }

        public RestClientException(string message)
            : base(message)
        {
        }

    }
}