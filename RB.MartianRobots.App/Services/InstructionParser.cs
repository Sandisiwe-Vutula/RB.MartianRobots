namespace RB.MartianRobots.App.Services
{
    public class InstructionParser
    {
        public (Grid grid, List<(Robot robot, List<ICommand> commands)> instructions) Parse(string[] input)
        {
            // Filter out empty or whitespace-only lines
            input = input.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            var gridParts = input[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var grid = new Grid(int.Parse(gridParts[0]), int.Parse(gridParts[1]));

            var robots = new List<(Robot, List<ICommand>)>();
            for (int i = 1; i < input.Length; i += 2)
            {
                var position = input[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var x = int.Parse(position[0]);
                var y = int.Parse(position[1]);
                var orientation = Enum.Parse<Direction>(position[2]);
                var robot = new Robot(x, y, orientation);

                var commands = new List<ICommand>();
                foreach (char c in input[i + 1])
                {
                    if (char.IsWhiteSpace(c)) continue;

                    commands.Add(c switch
                    {
                        'L' => new LeftCommand(),
                        'R' => new RightCommand(),
                        'F' => new ForwardCommand(),
                        _ => throw new Exception($"Invalid command: {c}")
                    });
                }

                robots.Add((robot, commands));
            }

            return (grid, robots);
        }
    }
}
