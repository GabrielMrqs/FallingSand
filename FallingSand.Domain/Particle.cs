using System.Drawing;

namespace FallingSand.Domain
{
    public class Particle
    {
        public Particle(int x, int y, int width, int height, Brush brush)
        {
            Y = y;
            X = x;
            Width = width;
            Height = height;
            Brush = brush;
            Static = false;
        }

        public int Y { get; set; }
        public int X { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Brush Brush { get; set; }
        public bool Static { get; set; }

        public void Move(Direction mov, int vel)
        {
            switch (mov)
            {
                case Direction.Down: Y += vel; break;

                case Direction.Up: Y -= vel; break;

                case Direction.Left: X -= vel; break;

                case Direction.Right: X += vel; break;

                default: throw new ArgumentOutOfRangeException();
            }
        }
        public void UpdateStatus()
        {
            Static = true;
        }
        public Direction GetDirection(Particle particleAnom)
        {
            if (Y < particleAnom.Y)
                return Direction.Down;

            if (Y > particleAnom.Y)
                return Direction.Up;

            if (X < particleAnom.X)
                return Direction.Right;

            if (X > particleAnom.X)
                return Direction.Left;

            return Direction.None;
        }
        public bool OnGround(int height)
        {
            return Y == height;
        }
        public override string ToString()
        {
            return $"X: {X} Y: {Y}";
        }
    }
    public enum Direction
    {
        Down, Up, Left, Right, None
    }


}
