using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                switch (command.Trim("[0-9 ]"))
                {
                    case FORWARD:
                        var x = parseCommand(command, FORWARD);
                        depth += aim * x;
                        horz += x;
                        break;
                    case UP:
                        aim -= parseCommand(command, UP);
                        break;
                    case DOWN:
                        aim += parseCommand(command, DOWN);
                        break;
                }

            }

            return depth * horz;
        }

        static int parseCommand(string command, string action)
        {
            return int.Parse(command.Replace(action, ""));
        }

    }
}
