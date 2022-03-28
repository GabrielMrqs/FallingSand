using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public int Y { get; set; }
        public int X { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Brush Brush { get; set; }

        public void Move(Direction mov)
        {
            switch (mov)
            {
                case Direction.Down: Y += 1; break;

                case Direction.Up: Y -= 1; break;

                case Direction.Left: X -= 1; break;

                case Direction.Right: X += 1; break;

                default: throw new ArgumentOutOfRangeException();
            }
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
        Down, Up, Left, Right,None
    }

}
