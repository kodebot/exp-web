using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    public class Game
    {
        private readonly Board<CellValueOption> _board;
        private GameStatus _status;
        private readonly Dictionary<Player, CellValueOption> _playerOption;

        public Game()
        {
            _board = new Board<CellValueOption>();
            _playerOption = new Dictionary<Player, CellValueOption>
            {
                [Player.Player1] = CellValueOption.Cross,
                [Player.Player2] = CellValueOption.Nought
            };
        }

        public Board<CellValueOption> Board => _board;
        public GameStatus Status => _status;
        public async Task Play(int row, int col)
        {
            if (IsGameOver())
            {
                return;
            }

            _board.Fill(new Coordinates(row, col), GetCurrentPlayerCellValue());

            var (hasWinner, winningCells) = GetWinner();
            if (hasWinner)
            {
                var winner = _playerOption.First(p => p.Value == winningCells.First().Value).Key;
               
            }
            else
            {
                RotateTurn();
                // if new turn is computers then play computer's turn
                if (_status == GameStatus.Player2Turn)
                {
                    await Task.Delay(2000);
                    await PlayComputerTurn(); // todo: move this to event based
                }
            }
        }

        private CellValueOption GetCurrentPlayerCellValue()
        {
            return _status switch 
            {
                
                GameStatus.Player1Turn => _playerOption[Player.Player1],
                GameStatus.Player2Turn => _playerOption[Player.Player2],
                _ => throw new InvalidOperationException("Cannot get the player's option when it is not one of the player's turn");
            };
        }

        private bool IsGameOver()
        {
            return _status == GameStatus.Player1Won || _status == GameStatus.Player2Won || _status == GameStatus.Tie;
        }

        public void RotateTurn()
        {
            _status = _status switch 
            {
                GameStatus.Player1Turn => GameStatus.Player2Turn,
                GameStatus.Player2Turn => GameStatus.Player1Turn,
                _ => _status // ignore
                
            };
        }

        public async Task PlayComputerTurn()
        {
            // find random empty cell
            var random = new Random();
            while (true)
            {
                var row = random.Next(0, 3);
                var col = random.Next(0, 3);
                if (_board[row, col] == CellValueOption.Empty)
                {
                    await Play(row, col);
                    break;
                }
            }
        }

        private (bool, IReadOnlyList<Cell<CellValueOption>>) GetWinner()
        {
            var hasWinner = false;
            var winningCells = new List<Cell<CellValueOption>>();

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

        private static bool IsAllFilledWithSameNonEmptyValue(Cell<CellValueOption>[] cells)
        {
            return cells.All(c => c.Value != CellValueOption.Empty) && cells.GroupBy(c => c.Value).Count() == 1;
        }
    }
}
