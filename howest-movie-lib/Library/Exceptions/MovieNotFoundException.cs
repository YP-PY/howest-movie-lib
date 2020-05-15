using System;
namespace howest_movie_lib.Library.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(){}
        public MovieNotFoundException(string message)
        : base(message)
        {}
        public MovieNotFoundException(string message, Exception inner)
        : base(message, inner)
        {}   
    }
}