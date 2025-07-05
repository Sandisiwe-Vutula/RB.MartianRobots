namespace RB.MartianRobots.Tests
{
    public class RobotTests
    {
        [Fact]
        public void Robot_ThenInitializeWithCorrectPositionAndOrientation()
        {
            // Arrange
            var robot = new Robot(2, 3, Direction.E);

            // Assert
            Assert.Equal(2, robot.X);
            Assert.Equal(3, robot.Y);
            Assert.Equal(Direction.E, robot.Orientation);
            Assert.False(robot.IsLost);
        }

        [Fact]
        public void MarkLost_ThenSetIsLostToTrue()
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.N);

            // Act
            robot.MarkLost();

            // Assert
            Assert.True(robot.IsLost);
        }

        [Fact]
        public void Robot_Position_CanBeUpdated()
        {
            // Arrange
            var robot = new Robot(1, 1, Direction.S);

            // Act
            robot.X = 4;
            robot.Y = 5;

            // Assert
            Assert.Equal(4, robot.X);
            Assert.Equal(5, robot.Y);
        }

        [Fact]
        public void Robot_Orientation_CanBeChanged()
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.W);

            // Act
            robot.Orientation = Direction.N;

            // Assert
            Assert.Equal(Direction.N, robot.Orientation);
        }
    }
}
