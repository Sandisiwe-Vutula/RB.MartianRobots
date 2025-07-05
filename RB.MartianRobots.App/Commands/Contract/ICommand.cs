namespace RB.MartianRobots.App.Commands.Contract
{
    public interface ICommand
    {
        void Execute(Robot robot, Grid grid);
    }
}
