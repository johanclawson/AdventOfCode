using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day5
    {
        const string FILENAME = "5sample.txt";
        public static int Part1()
        {
            var matrixSize = 10;
            var matrix = new int[matrixSize, matrixSize];

            var inputRows = File.ReadAllLines(FILENAME).Select(a => a.Split("->"))
                .Select(a => new
                {
                    StartLine = a[0].Trim().Split(","),
                    EndLine = a[1].Trim().Split(",")
                })
                .Select(a => new SimpleCoordinate
                {
                    X1 = int.Parse(a.StartLine[0]),
                    X2 = int.Parse(a.EndLine[0]),
                    Y1 = int.Parse(a.StartLine[1]),
                    Y2 = int.Parse(a.EndLine[1])
                })
                .Where(a => a.X1 == a.X2 || a.Y1 == a.Y2)
                .ToList();

            inputRows.Where(a => a.Y1 == a.Y2).ToList().ForEach(a =>
            {
                var steps = Math.Abs(a.X2 - a.X1);
                var lowest = a.X1 < a.X2 ? a.X1 : a.X2;
                for (int i = lowest; i <= lowest + steps; i++)
                {
                    matrix[i, a.Y1]++;
                }
            });

            inputRows.Where(a => a.X1 == a.X2).ToList().ForEach(a =>
            {
                var steps = Math.Abs(a.Y2 - a.Y1);
                var lowest = a.Y1 < a.Y2 ? a.Y1 : a.Y2;
                for (int i = lowest; i <= lowest + steps; i++)
                {
                    matrix[a.X1, i]++;
                }
            });

            var cnt = 0;
            for (int x = 0; x < matrixSize; x++)
                for (int y = 0; y < matrixSize; y++)
                    if (matrix[x,y] > 1) 
                        cnt++;


            return cnt;

        }


        public static int Part2()
        {
            return -1;
        }

    }

    internal class SimpleCoordinate
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
    }
}
