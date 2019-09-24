using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core
{
    public class Game
    {
        private readonly Board<Option> _board;
        private Player? _winner;
        private Player _turn;
        private readonly Dictionary<Player, Option> _playerOption;

        public Game()
        {
            _board = new Board<Option>();
            _turn = Player.Player1;
            _playerOption = new Dictionary<Player, Option>
            {
                [Player.Player1] = Option.Cross,
                [Player.Player2] = Option.Nought
            };
        }

        public Board<Option> Board => _board;

        public Player? Winner => _winner;

        public Player Turn => _turn;

        public void Play(int row, int col)
        {
            if (_winner != null)
            {
                return;  // game over
            }

            _board.Fill(new Coordinates(row, col), _playerOption[_turn]);

            var (hasWinner, winningCells) = GetWinner();
            if (hasWinner)
            {
                _winner = _playerOption.First(p => p.Value == winningCells.First().Value).Key;
            }
            else
            {
                RotateTurn();
                // if new turn is computers then play computer's turn
                if (_turn == Player.Player2)
                {
                    PlayComputerTurn(); // todo: move this to event based
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
                var row = random.Next(0, 3);
                var col = random.Next(0, 3);
                if (_board[row, col] == Option.Empty)
                {
                    Play(row, col);
                    break;
                }
            }
        }

        private (bool, IReadOnlyList<Cell<Option>>) GetWinner()
        {
            var hasWinner = false;
            var winningCells = new List<Cell<Option>>();

            // horizontals
            foreach (var row in _board.Rows)
            {
                if (IsAllFilledWithSameNonEmptyValue(row))
                {
                    hasWinner = true;
                    winningCells = row.ToList();
                    return (hasWinner, winningCells);
                }
            }

            // verticals
            foreach (var col in _board.Columns)
            {
                if (IsAllFilledWithSameNonEmptyValue(col))
                {
                    hasWinner = true;
                    winningCells = col.ToList();
                    return (hasWinner, winningCells);
                }
            }

            // diagonal - top left to bottom right
            if (IsAllFilledWithSameNonEmptyValue(_board.LeftToRightDiagonal))
            {
                hasWinner = true;
                winningCells = _board.LeftToRightDiagonal.ToList();
                return (hasWinner, winningCells);
            }

            // diagonal - top right to bottom left
            if (IsAllFilledWithSameNonEmptyValue(_board.RightToLeftDiagonal))
            {
                hasWinner = true;
                winningCells = _board.RightToLeftDiagonal.ToList();
                return (hasWinner, winningCells);
            }

            return (hasWinner, winningCells); // no winner
        }

        private static bool IsAllFilledWithSameNonEmptyValue(Cell<Option>[] cells)
        {
            return cells.All(c => c.Value != Option.Empty) && cells.GroupBy(c => c.Value).Count() == 1;
        }
    }
}
