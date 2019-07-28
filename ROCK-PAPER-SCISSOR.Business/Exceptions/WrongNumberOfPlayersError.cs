using System;

namespace ROCK_PAPER_SCISSOR.Business.Exceptions
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError()
        {
        }

        public WrongNumberOfPlayersError(string message) : base(message)
        {
        }
    }
}
