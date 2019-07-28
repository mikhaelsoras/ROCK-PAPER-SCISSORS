using ROCK_PAPER_SCISSOR.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCK_PAPER_SCISSOR.Business
{
    public class Game
    {
        public Game()
        {
            /// Lista de brackets
            /// - Lista de Jogadores
            /// - - Detalhes do Jogador

            string[][][] brackets = new string[][][] {
                new string[][]{
                    new string[] { "Armando", "P"},
                    new string[] { "Richard", "R"},
                },

                new string[][]{
                    new string[] { "Allen", "P"},
                    new string[] { "David", "P"},
                }
            };

            rps_game_winner(brackets);
        }

        public string[] rps_game_winner(string[][][] brackets)
        {
            validade_players_strategy(brackets);

            return null;
        }

        private void validade_players_strategy(string[][][] brackets)
        {
            foreach(var players in brackets)
            {
                if (players.Length != 2)
                    throw new WrongNumberOfPlayersError();

                foreach (var player in players)
                {
                    if (player[1].ToUpper() == "R" || player[1].ToUpper() == "P" || player[1].ToUpper() == "S")
                        continue;
                    else
                        throw new NoSuchStrategyError();
                }
            }
        }
    }
}
