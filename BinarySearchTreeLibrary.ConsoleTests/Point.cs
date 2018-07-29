namespace BinarySearchTreeLibrary.ConsoleTests
{
    public struct Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return $"{nameof(this.X)}: {this.X}, {nameof(this.Y)}: {this.Y}";
        }
    }
}
