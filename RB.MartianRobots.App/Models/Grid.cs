namespace RB.MartianRobots.App.Models
{
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }
        private HashSet<(int x, int y)> scents = new();

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsOffGrid(int x, int y) => x < 0 || y < 0 || x > Width || y > Height;
        public bool IsScented(int x, int y) => scents.Contains((x, y));
        public void AddScent(int x, int y) => scents.Add((x, y));
    }
}
