namespace AdventOfCode
{
    public static class Day3
    {
        public static int Part1()
        {
            var fileName = "3.txt";
            var binaries = File.ReadAllLines(fileName).Select(a => a.ToArray());
            var length = binaries.First().Length;

            var sortMethods = (SortMethod[])Enum.GetValues(typeof(SortMethod));

            var numPos = sortMethods.Select(sortMethod => string.Join("", Enumerable.Range(0, length)
                            .Select(i => binaries.Select(a => a[i])
                            .GroupBy(a => a).OrderBySortMethod(a => a.Count(), sortMethod).First())
                            .Select(a => a.Key)
                            .ToList()))
                            .Select(a => Convert.ToInt32(a, 2));

            var result = numPos.Aggregate(1, (x, y) => x * y);

            return result;
        }
    }
}
