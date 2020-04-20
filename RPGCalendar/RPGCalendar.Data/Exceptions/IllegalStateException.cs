namespace RPGCalendar.Data.Exceptions
{
    using System;

    public class IllegalStateException : Exception 
    {
        public IllegalStateException(string prop)
        : base($"{prop} is found in an illegal state")
        { }
    }
}
