namespace AdventOfCode
{
    public static class Day2
    {

        public static int Part1()
        {
            var fileName = "2.txt";
            var commands = File.ReadAllLines(fileName);

            var vert = 0;
            var horz = 0;

            foreach (var command in commands)
            {
                var forward = "forward";
                if (command.StartsWith(forward))
                    horz += int.Parse(command.Replace(forward, ""));

                var down = "down";
                if (command.StartsWith(down))
                    vert += int.Parse(command.Replace(down, ""));

                var up = "up";
                if (command.StartsWith(up))
                    vert -= int.Parse(command.Replace(up, ""));
            }

            return vert * horz;
        }




        const string FORWARD = "forward";
        const string UP = "up";
        const string DOWN = "down";

        public static int Part2()
        {
            var fileName = "2.txt";
            var commands = File.ReadAllLines(fileName);

            var depth = 0;
            var horz = 0;
            var aim = 0;

            foreach (var command in commands)
            {
                var action = command.Trim("[0-9 ]");
                var getUnits = () => int.Parse(command.Replace(action, ""));

                switch (action)
                {
                    case FORWARD:
                        var x = getUnits();
                        depth += aim * x;
                        horz += x;
                        break;
                    case UP:
                        aim -= getUnits();
                        break;
                    case DOWN:
                        aim += getUnits();
                        break;
                }

            }

            return depth * horz;
        }
    }
}
