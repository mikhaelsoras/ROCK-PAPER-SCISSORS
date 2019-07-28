using System;
using System.Collections.Generic;
using ROCK_PAPER_SCISSOR.Business.Exceptions;
using ROCK_PAPER_SCISSOR.Business.Extension;

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
                new string[][]
                {
                    new string[] { "Armando", "P"},
                    new string[] { "Dave", "S"},
                },

                new string[][]
                {
                    new string[] { "Richard", "R"},
                    new string[] { "Michael", "S"},
                },

                new string[][]
                {
                    new string[] { "Allen", "S"},
                    new string[] { "Omer", "P"},
                },

                new string[][]
                {
                    new string[] { "David E.", "R"},
                    new string[] { "Richard X.", "P"},
                }
            };

            var winner = rps_game_winner(brackets);
        }

        public string[] rps_game_winner(string[][][] brackets)
        {
            var winners = new List<string[]>();

            foreach (var players in brackets)
                winners.Add(get_winner(players));

            if (winners.Count == 1)
                return winners[0];

            return rps_game_winner(players_to_brackets(winners.ToArray()));
        }

        private string[][][] players_to_brackets(string[][] players)
        {
            var brackets = new List<string[][]>();

            for (int i = 0; i < players.Length; i += 2)
            {
                string[][] bracket = new string[][]
                {
                    players[i],
                    players[i + 1]
                };

                brackets.Add(bracket);
            }

            return brackets.ToArray();
        }

        private string[] get_winner(string[][] players)
        {
            if (players.Length != 2)
                throw new WrongNumberOfPlayersError();

            if (players[0][1].ToUpper() == players[1][1].ToUpper())
                return players[0];
            return players[0][1].StrategyWinsAgainst(players[1][1]) ? players[0] : players[1];
        }
    }
}
