using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingSand.Domain
{
    public class Render
    {
        public List<Particle> Particles { get; set; } = new();
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap? Bitmap { get; set; }

        public Bitmap Draw()
        {
            using Graphics g = Graphics.FromImage(Bitmap!);
            g.Clear(Color.White);
            foreach (var particle in Particles)
            {
                g.FillRectangle(particle.Brush, particle.X, particle.Y, particle.Width, particle.Height);
            }
            return Bitmap!;
        }

        public void UpdateScreenSize(int width, int height)
        {
            Width = width;
            Height = height;
            Bitmap = new(width, height);
        }
    }
}
