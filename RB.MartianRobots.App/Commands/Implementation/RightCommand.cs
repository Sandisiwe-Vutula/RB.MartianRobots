namespace RB.MartianRobots.App.Commands.Implementation
{
    public class RightCommand : ICommand
    {
        public void Execute(Robot robot, Grid grid)
        {
            robot.Orientation = robot.Orientation switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => robot.Orientation
            };
        }
    }
}
