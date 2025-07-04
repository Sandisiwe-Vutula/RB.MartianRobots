namespace RB.MartianRobots.App.Models
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Orientation { get; set; }
        public bool IsLost { get; private set; } = false;

        public Robot(int x, int y, Direction orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public void MarkLost() => IsLost = true;
    }
}
