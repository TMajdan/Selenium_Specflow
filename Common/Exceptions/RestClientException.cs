namespace Task_TMajdan.Src.Exceptions
{
    using System;

    public class RestClientException : Exception
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
