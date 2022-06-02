using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day6
    {
        const string FILENAME = "6sample.txt";
        public static int Part1()
        {
            var startDays = File.ReadAllText(FILENAME).Split(",").Select(a => int.Parse(a));
            foreach (var day in startDays)
            {
                new LanternFish(day);
            }

            for (int i = 0; i < 80; i++)
            {
                LanternFish.NewDayBreed();
            }

            return LanternFish.GetNumFishes();
        }


        public static int Part2()
        {
            return -1;
        }

        class LanternFish
        {
            static List<LanternFish> fishList = new List<LanternFish>();
            static int _day;

            int _daysToSpawn = 0;
            public LanternFish(int daysToSpawn)
            {
                _daysToSpawn = daysToSpawn;
                fishList.Add(this);
            }

            //A lanternfish that creates a new fish resets its timer to 6, not 7 (because 0 is included as a valid timer value).
            //The new lanternfish starts with an internal timer of 8 and does not start counting down until the next day.
            public static void NewDayBreed()
            {
                var numOfFishesToAdd = 0;
                foreach (var fish in fishList)
                {
                    if (fish._daysToSpawn == 0)
                    {
                        fish._daysToSpawn = 6;
                        numOfFishesToAdd++;
                        
                    }
                    else
                    {
                        fish._daysToSpawn--;
                    }
                }

                // Add new fishes - not allowed to modify list while enumerating
                for (int i = 0; i < numOfFishesToAdd; i++)
                {
                    new LanternFish(8);
                }

                _day++;


            }

            public static int GetNumFishes()
            {
                return fishList.Count;
            }
        }

    }

}
