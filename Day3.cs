namespace AdventOfCode
{
    public static class Day3
    {
        const string FILENAME = "3.txt";
        public static int Part1()
        {

            var binaries = File.ReadAllLines(FILENAME).Select(a => a.ToArray());
            var length = binaries.First().Length;

            var sortMethods = (SortMethod[])Enum.GetValues(typeof(SortMethod));

            var decimals = sortMethods.Select(sortMethod => string.Join("", Enumerable.Range(0, length)
                                .Select(i => binaries.Select(a => a[i])
                                .GroupBy(a => a).OrderBySortMethod(a => a.Count(), sortMethod).First())
                                .Select(a => a.Key)
                                .ToList()))
                                .Select(a => Convert.ToInt32(a, 2));

            var result = decimals.Aggregate((x, y) => x * y);

            return result;
        }

        public static int Part2()
        {
            var binaries = File.ReadAllLines(FILENAME);
            var length = binaries.First().Length;


            var commons = (Common[])Enum.GetValues(typeof(Common));
            var outputs = new List<int>();

            foreach (var common in commons)
            {
                IEnumerable<BinaryResult> result = null;
                foreach (var pos in Enumerable.Range(0, length))
                {
                    result = result?.Select(a => new BinaryResult { Orig = a.Orig, Pos = a.Orig[pos] }) ?? binaries.Select(a => new BinaryResult { Orig = a, Pos = a[pos] });
                    
                    var ones = result.Where(a => a.Pos == '1');
                    var zeros = result.Where(a => a.Pos == '0');

                    result = common == Common.MostCommon ? ones.Count() >= zeros.Count() ? ones : zeros :
                                                           ones.Count() < zeros.Count() ? ones : zeros;

                    if (result.Count() == 1)
                        break;
                }
                outputs.Add(Convert.ToInt32(result.First().Orig, 2));
            }


            return outputs.Aggregate((x, y) => x * y);
        }

        class BinaryResult
        {
            public string Orig { get; set; }
            public char Pos { get; set; }

        }
    }
}
