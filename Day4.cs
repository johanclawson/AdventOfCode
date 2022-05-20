using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day4
    {
        const string FILENAME = "4.txt";
        const int BOARDSIZE = 5;
        public static int Part1()
        {
            var inputRows = File.ReadAllLines(FILENAME);
            var inputNumbers = inputRows.First().Split(',').Select(a => int.Parse(a));
            var bboards = inputRows.Skip(1)
                                .Where(a => a.Trim() != string.Empty)
                                .Chunk(BOARDSIZE)
                                .Select(a => new BBoard(a, BOARDSIZE))
                                .ToList();

            foreach (var number in inputNumbers)
            {
                foreach (var board in bboards)
                {
                    var checkPos = board.CheckNumber(number);
                    if (checkPos.x > -1)
                    {
                        if (board.IsBingo(checkPos.x, checkPos.y))
                        {
                            return board.GetNotCheckedSum() * number;
                        }
                    }
                }
            }

            return -1;
        }

        public static int Part2()
        {

            var inputRows = File.ReadAllLines(FILENAME);
            var inputNumbers = inputRows.First().Split(',').Select(a => int.Parse(a));
            var bboards = inputRows.Skip(1)
                                .Where(a => a.Trim() != string.Empty)
                                .Chunk(BOARDSIZE)
                                .Select(a => new BBoard(a, BOARDSIZE))
                                .ToList();

            BBoard lastWinningBoard = null;
            int lastWinningNumber = -1;
            foreach (var number in inputNumbers)
            {
                foreach (var board in bboards)
                {
                    if (board.HasWon)
                    {
                        continue;
                    }

                    var checkPos = board.CheckNumber(number);
                    if (checkPos.x > -1)
                    {
                        if (board.IsBingo(checkPos.x, checkPos.y))
                        {
                            lastWinningBoard = board;
                            lastWinningNumber = number;  
                        }
                    }
                }
            }

            return lastWinningBoard.GetNotCheckedSum() * lastWinningNumber;
        }

    }

    struct BCheck
    {
        public int Number { get; set; }
        public bool IsChecked { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    class BBoard
    {
        public bool HasWon { get; set; }

        BCheck[,] _board;
        private int _boardSize;
        public BBoard(string[] dataInput, int boardSize)
        {
            _boardSize = boardSize;
            _board = new BCheck[_boardSize, _boardSize];
            for (int y = 0; y < boardSize; y++)
            {
                var row = Regex.Split(dataInput[y].Trim(), @"\s+");
                for (int x = 0; x < boardSize; x++)
                {
                    _board[y, x] = new BCheck { Number = int.Parse(row[x]) };
                }
            }
        }

        public int GetNotCheckedSum()
        {
            var sum = 0;
            for (int x = 0; x < _boardSize; x++)
            {
                for (int y = 0; y < _boardSize; y++)
                {
                    if (_board[x, y].IsChecked == false)
                    {
                        sum += _board[x, y].Number;
                    }
                }
            }

            return sum;
        }

        public (int x, int y) CheckNumber(int number)
        {
            for (int x = 0; x < _boardSize; x++)
            {
                for (int y = 0; y < _boardSize; y++)
                {
                    if (_board[x, y].Number == number)
                    {
                        _board[x, y].IsChecked = true;
                        return (x, y);
                    }
                }
            }

            return (-1, -1);
        }

        public bool IsBingo(int x, int y)
        {
            var isXBingo = Enumerable.Range(0, _boardSize)
                            .All(x => _board[x, y].IsChecked);

            var isYBingo = Enumerable.Range(0, _boardSize)
                            .All(y => _board[x, y].IsChecked);

            return HasWon = isXBingo || isYBingo;
        }
    }
}
