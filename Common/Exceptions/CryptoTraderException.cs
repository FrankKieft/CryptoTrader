using System;

namespace Common
{
    public class CryptoTraderException : Exception
    {
        public CryptoTraderException() : base()
        {

        }
        public CryptoTraderException(string? message) : base(message)
        {

        }
        public CryptoTraderException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
