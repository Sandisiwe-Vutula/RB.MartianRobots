
var inputPath = args.Length > 0 ? args[0] : "Input/SampleInput.txt";

if (!File.Exists(inputPath))
{
    Console.WriteLine($"Input file not found: {inputPath}");
    return;
}

string[] inputLines = File.ReadAllLines(inputPath);

var parser = new InstructionParser();
var (grid, robotInstructions) = parser.Parse(inputLines);

foreach (var (robot, commands) in robotInstructions)
{
    foreach (var command in commands)
    {
        command.Execute(robot, grid);
        if (robot.IsLost) break;
    }

    Console.WriteLine($"{robot.X} {robot.Y} {robot.Orientation}{(robot.IsLost ? " LOST" : "")}");
}
