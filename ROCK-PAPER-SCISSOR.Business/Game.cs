using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ROCK_PAPER_SCISSOR.Business.Exceptions;
using ROCK_PAPER_SCISSOR.Business.Extension;

namespace ROCK_PAPER_SCISSOR.Business
{
    public class Game
    {
        /// <summary>
        /// A cada execução avalia as brackets atuais e seus vencedores. Caso haja um vencedor ele é retornado, 
        /// se náo ouver ele criar uma bracket nova com os vencedores dessa rodada e continuar avaliando recursivamente.
        /// </summary>
        /// <param name="brackets"></param>
        /// <returns></returns>
        public string[] rps_game_winner(string[][][] brackets)
        {
            var winners = new List<string[]>();

            foreach (var players in brackets)
                winners.Add(get_winner(players));

            if (winners.Count == 1)
                return winners[0];

            return rps_game_winner(players_to_brackets(winners.ToArray()));
        }

        /// <summary>
        /// Faz a mesma coisa que rps_game_winner(string[][][] brackets), só que ele converte uma entrada para o array.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string[] rps_game_winner(string input)
        {
            return rps_game_winner(ParseString(input));
        }

        /// <summary>
        /// Converte a lista de jogadores para brackets de torneio.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida a quantidade de jogadores e retorna o ganhador.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        private string[] get_winner(string[][] players)
        {
            if (players.Length != 2)
                throw new WrongNumberOfPlayersError();

            if (players[0][1].ToUpper() == players[1][1].ToUpper())
                return players[0];
            return players[0][1].StrategyWinsAgainst(players[1][1]) ? players[0] : players[1];
        }

        /// <summary>
        /// Converte uma entrada em string para string[][][].
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string[][][] ParseString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Input string not informed.");

            string tournamentInput = input;
            if (tournamentInput.StartsWith("[[[["))
                tournamentInput = tournamentInput.Substring(1, input.Length - 2);

            try
            {
                var tournamentObject = JsonConvert.DeserializeObject<string[][][]>(tournamentInput);
                return tournamentObject;
            }
            catch (Exception e)
            {
                throw new Exception("Invalid input string.", e);
            }
        }
    }
}
