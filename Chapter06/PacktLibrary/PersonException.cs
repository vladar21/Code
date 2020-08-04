using System;
namespace Packt.CS6

{
    public class PersonException : Exception
    {
        public PersonException() : base() { }
        public PersonException(string message) : base(message) { }
        public PersonException(string message, Exception innerException) :
        base(message, innerException)
        { }
       
    }
}