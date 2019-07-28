using System;

namespace ROCK_PAPER_SCISSOR.Business.Exceptions
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError()
        {
        }

        public NoSuchStrategyError(string message) : base(message)
        {
        }
    }
}
