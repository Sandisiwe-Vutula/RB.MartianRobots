namespace RB.MartianRobots.Tests
{
    public class InstructionParserTests
    {
        [Fact]
        public void Parse_ThenCreateCorrectGrid()
        {
            // Arrange
            string[] input = new[]
            {
                "5 3",
                "1 1 E",
                "RFRFRFRF"
            };

            var parser = new InstructionParser();

            // Act
            var (grid, _) = parser.Parse(input);

            // Assert
            Assert.Equal(5, grid.Width);
            Assert.Equal(3, grid.Height);
        }

        [Fact]
        public void Parse_ThenCreateRobotWithCorrectInitialState()
        {
            // Arrange
            string[] input = new[]
            {
                "5 3",
                "3 2 N",
                "FRRFLLFFRRFLL"
            };

            var parser = new InstructionParser();

            // Act
            var (_, instructions) = parser.Parse(input);
            var (robot, commands) = instructions[0];

            // Assert
            Assert.Equal(3, robot.X);
            Assert.Equal(2, robot.Y);
            Assert.Equal(Direction.N, robot.Orientation);
            Assert.Equal(13, commands.Count);
        }

        [Fact]
        public void Parse_ThenIgnoreEmptyLines()
        {
            // Arrange
            string[] input = new[]
            {
                "5 3",
                "",
                "0 3 W",
                "LLFFFLFLFL",
                "",
                "1 1 E",
                "RFRFRFRF"
            };

            var parser = new InstructionParser();

            // Act
            var (_, instructions) = parser.Parse(input);

            // Assert
            Assert.Equal(2, instructions.Count);
        }

        [Fact]
        public void Parse_ThenThrowException_ForInvalidCommand()
        {
            // Arrange
            string[] input = new[]
            {
                "5 3",
                "1 1 E",
                "RXRF"
            };

            var parser = new InstructionParser();

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => parser.Parse(input));
            Assert.Contains("Invalid command", ex.Message);
        }

        [Fact]
        public void Parse_ThenParseMultipleRobotsCorrectly()
        {
            // Arrange
            string[] input = new[]
            {
                "5 3",
                "1 1 E",
                "RFRFRFRF",
                "3 2 N",
                "FRRFLLFFRRFLL"
            };

            var parser = new InstructionParser();

            // Act
            var (_, instructions) = parser.Parse(input);

            // Assert
            Assert.Equal(2, instructions.Count);
            Assert.Equal(8, instructions[0].commands.Count);
            Assert.Equal(13, instructions[1].commands.Count);
        }

        [Fact]
        public void Parse_ThenHandleTabsAndExtraWhitespace()
        {
            // Arrange
            string[] input = new[]
            {
                "5\t3",
                "\t1 1\tE  ",
                "R F R F R F R F"
            };

            var parser = new InstructionParser();

            // Act
            var (grid, instructions) = parser.Parse(input);
            var (robot, commands) = instructions[0];

            // Assert
            Assert.Equal(5, grid.Width);
            Assert.Equal(3, grid.Height);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal(Direction.E, robot.Orientation);
            Assert.Equal(8, commands.Count);
        }
    }
}
