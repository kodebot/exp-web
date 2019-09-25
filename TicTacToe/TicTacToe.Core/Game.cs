using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    public class Game
    {
        private readonly Board<CellMarker> _board;
        private GameStatus _status;
        private readonly Dictionary<Player, CellMarker> _playerMarker;

        public Game()
        {
            _board = new Board<CellMarker>();
            _playerMarker = new Dictionary<Player, CellMarker>
            {
                [Player.Player1] = CellMarker.Cross,
                [Player.Player2] = CellMarker.Nought
            };
        }

        public Board<CellMarker> Board => _board;
        public GameStatus Status => _status;
        public async Task Play(int row, int col)
        {
            if (IsGameOver())
            {
                return;
            }

            _board.Fill(new Coordinates(row, col), GetCellMarkerOfCurrentPlayer());
            RecalculateGameStatus();

            // if new turn is computers then play computer's turn
            if (_status == GameStatus.Player2Turn)
            {
                await Task.Delay(2000);
                await PlayComputerTurn(); // todo: move this to event based
            }

        }

        private async Task PlayComputerTurn()
        {
            // find random empty cell
            var random = new Random();
            while (true)
            {
                var row = random.Next(0, 3);
                var col = random.Next(0, 3);
                if (_board[row, col] == CellMarker.Empty)
                {
                    await Play(row, col);
                    break;
                }
            }
        }

        private CellMarker GetCellMarkerOfCurrentPlayer()
        {
            return _status switch
            {

                GameStatus.Player1Turn => _playerMarker[Player.Player1],
                GameStatus.Player2Turn => _playerMarker[Player.Player2],
                _ => throw new InvalidOperationException("Cannot get the player's option when it is not one of the player's turn")
            };
        }

        private Player GetPlayerFromCellMarker(CellMarker marker)
        {
            return _playerMarker.First(p => p.Value == marker).Key;
        }

        private bool IsGameOver()
        {
            return _status == GameStatus.Player1Won || _status == GameStatus.Player2Won || _status == GameStatus.Tie;
        }

        private void RecalculateGameStatus()
        {
            _status = GetGameStatus();
        }

        private GameStatus GetGameStatus()
        {
            var (hasWinner, winningCells) = GetWinner();

            if (hasWinner)
            {
                return GetWinnerGameStatus(winningCells.ToArray());
            }

            // any moves available?
            foreach (var row in _board.Rows)
            {
                if (row.Any(r => r.Value == CellMarker.Empty))
                {
                    return RotateTurn();
                }
            }

            return GameStatus.Tie;

            GameStatus GetWinnerGameStatus(Cell<CellMarker>[] row)
            {
                var player = GetPlayerFromCellMarker(row[0].Value);
                return player switch
                {
                    Player.Player1 => GameStatus.Player1Won,
                    Player.Player2 => GameStatus.Player2Won,
                    _ => throw new InvalidOperationException("This is impossible!")
                };
            }

            GameStatus RotateTurn()
            {
                return _status switch
                {
                    GameStatus.Player1Turn => GameStatus.Player2Turn,
                    GameStatus.Player2Turn => GameStatus.Player1Turn,
                    _ => _status // ignore

                };
            }
        }

        private (bool, Cell<CellMarker>[]) GetWinner()
        {
            var hasWinner = false;
            var winningCells = new List<Cell<CellMarker>>();

            // horizontals
            foreach (var row in _board.Rows)
            {
                if (IsAllMarkedWithSameNonEmptyValue(row))
                {
                    hasWinner = true;
                    winningCells = row.ToList();
                    return (hasWinner, winningCells.ToArray());
                }
            }

            // verticals
            foreach (var col in _board.Columns)
            {
                if (IsAllMarkedWithSameNonEmptyValue(col))
                {
                    hasWinner = true;
                    winningCells = col.ToList();
                    return (hasWinner, winningCells.ToArray());
                }
            }

            // diagonal - top left to bottom right
            if (IsAllMarkedWithSameNonEmptyValue(_board.LeftToRightDiagonal))
            {
                hasWinner = true;
                winningCells = _board.LeftToRightDiagonal.ToList();
                return (hasWinner, winningCells.ToArray());
            }

            // diagonal - top right to bottom left
            if (IsAllMarkedWithSameNonEmptyValue(_board.RightToLeftDiagonal))
            {
                hasWinner = true;
                winningCells = _board.RightToLeftDiagonal.ToList();
                return (hasWinner, winningCells.ToArray());
            }

            return (hasWinner, winningCells.ToArray()); // no winner
        }

        private static bool IsAllMarkedWithSameNonEmptyValue(Cell<CellMarker>[] cells)
        {
            return cells.All(c => c.Value != CellMarker.Empty) && cells.GroupBy(c => c.Value).Count() == 1;
        }
    }
}
