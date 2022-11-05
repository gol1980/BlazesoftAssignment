using System;
using System.Globalization;
using System.Net;

namespace SlotMachine.API.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode _HttpStatusCode { get; set; }
        public AppException(HttpStatusCode HttpStatusCode)
            : base()
        {
            _HttpStatusCode = HttpStatusCode;
        }

        public AppException(string message, HttpStatusCode HttpStatusCode) : base(message) { _HttpStatusCode = HttpStatusCode; }

        public AppException(string message, HttpStatusCode HttpStatusCode, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
            _HttpStatusCode = HttpStatusCode;
        }
    }
}
