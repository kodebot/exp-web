using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core
{

    public class Game
    {
        private readonly Option[][] _board;
        private Player? _winner;
        private Player _turn;
        private readonly Dictionary<Player, Option> _playerOption;

        public Game()
        {
            _board = new Option[3][] { new Option[3], new Option[3], new Option[3] };
            _turn = Player.Player1;
            _playerOption = new Dictionary<Player, Option>
            {
                [Player.Player1] = Option.Cross,
                [Player.Player2] = Option.Nought
            };
        }

        public Option[][] Board => _board;

        public Player? Winner => _winner;

        public Player Turn => _turn;

        public void Play(int row, int col)
        {
            if (_winner != null)
            {
                return;  // game over
            }

            _board[row][col] = _playerOption[_turn];
            CheckWinning();

            if (_winner == null)
            {
                RotateTurn();

                // if new turn is computers then play computer's turn
                if (_turn == Player.Player2)
                {
                    PlayComputerTurn();
                }
            }
        }

        public void RotateTurn()
        {
            if (_turn == Player.Player1)
            {
                _turn = Player.Player2;
                return;
            }
            _turn = Player.Player1;
        }

        public void PlayComputerTurn()
        {
            // find random empty cell
            var random = new Random();
            while (true)
            {
                var row = random.Next(0, 2);
                var col = random.Next(0, 2);
                if (_board[row][col] == Option.Empty)
                {
                    Play(row, col);
                    break;
                }
            }
        }

        private void CheckWinning()
        {
            // horizontals
            foreach (var row in _board)
            {
                if (row[0] != Option.Empty &&
                    row[0] == row[1] &&
                    row[1] == row[2])
                {
                    _winner = _playerOption.First(p => p.Value == row[0]).Key;
                    return;
                }
            }

            // verticals
            for (var colIndex = 0; colIndex < 3; colIndex++)
            {
                if (_board[0][colIndex] != Option.Empty &&
                    _board[0][colIndex] == _board[1][colIndex] &&
                    _board[1][colIndex] == _board[2][colIndex])
                {
                    _winner = _playerOption.First(p => p.Value == _board[0][colIndex]).Key;
                    return;
                }
            }

            // diagonal - top left to bottom right
            if (_board[0][0] != Option.Empty && _board[0][0] == _board[1][1] && _board[1][1] == _board[2][2])
            {
                _winner = _playerOption.First(p => p.Value == _board[0][0]).Key;
                return;
            }

            // diagonal - top right to bottom left
            if (_board[0][2] != Option.Empty && _board[0][2] == _board[1][1] && _board[1][1] == _board[2][0])
            {
                _winner = _playerOption.First(p => p.Value == _board[0][0]).Key;
                return;
            }
        }

    }
}
