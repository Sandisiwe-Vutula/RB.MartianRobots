namespace RB.MartianRobots.App.Commands.Implementation
{
    public class LeftCommand : ICommand
    {
        public void Execute(Robot robot, Grid grid)
        {
            robot.Orientation = robot.Orientation switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => robot.Orientation
            };
        }
    }
}
