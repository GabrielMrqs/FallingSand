using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingSand
{
    public struct Particle
    {
        public Particle()
        {
            Height = 4;
            Widht = 4;
            Brush = Brushes.Black;
        }

        public int Height { get; set; }
        public int Widht { get; set; }
        public Brush Brush { get; set; }
    }
}
