using ROCK_PAPER_SCISSOR.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCK_PAPER_SCISSOR.Business.Extension
{
    public static class GameExtensions
    {
        public static bool ValidStrategy(string strategy)
        {
            return strategy.ToUpper() == "R" || strategy.ToUpper() == "P" || strategy.ToUpper() == "S";
        }

        public static bool StrategyWinsAgainst(this string strategy, string counter_strategy)
        {
            if (!ValidStrategy(counter_strategy))
                throw new NoSuchStrategyError();

            switch (strategy.ToUpper())
            {
                case "R":
                    if (counter_strategy.ToUpper() == "S")
                        return true;
                    else
                        return false;

                case "P":
                    if (counter_strategy.ToUpper() == "R")
                        return true;
                    else
                        return false;

                case "S":
                    if (counter_strategy.ToUpper() == "P")
                        return true;
                    else
                        return false;

                default:
                    throw new NoSuchStrategyError();
            }
        }
    }
}
