namespace RB.MartianRobots.App.Commands.Implementation
{
    public class ForwardCommand : ICommand
    {
        public void Execute(Robot robot, Grid grid)
        {
            int x = robot.X, y = robot.Y;
            switch (robot.Orientation)
            {
                case Direction.N: y += 1; break;
                case Direction.E: x += 1; break;
                case Direction.S: y -= 1; break;
                case Direction.W: x -= 1; break;
            }

            if (grid.IsOffGrid(x, y))
            {
                if (!grid.IsScented(robot.X, robot.Y))
                {
                    grid.AddScent(robot.X, robot.Y);
                    robot.MarkLost();
                }
                return;
            }

            robot.X = x;
            robot.Y = y;
        }
    }
}
