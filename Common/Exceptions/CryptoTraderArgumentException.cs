using System;

namespace Common
{
    public class CryptoTraderArgumentException : CryptoTraderException
    {
        public CryptoTraderArgumentException() : base()
        {

        }
        public CryptoTraderArgumentException(string? message) : base(message)
        {

        }
        public CryptoTraderArgumentException(string? message, Exception? innerException) : base (message, innerException)
        {

        }
    }
}
