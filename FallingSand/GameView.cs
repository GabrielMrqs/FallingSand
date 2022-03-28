using System.Drawing;
using System.Linq;

namespace FallingSand
{
    public partial class GameView : Form
    {
        private int gravity = 1;
        private int w = 4;
        private int maxWidth;
        private int maxHeight;
        private Particle?[,] particles;
        private Bitmap bm;
        public GameView()
        {
            InitializeComponent();
            LoadVariables();
        }

        private void LoadVariables()
        {
            maxWidth = pictureBox1.Width;
            maxHeight = pictureBox1.Height;
            particles = new Particle?[maxWidth, maxHeight];
            bm = new(maxWidth, maxHeight);
        }

        private void MainLoop()
        {
            for (int i = 0; i < maxWidth; i++)
            {
                for (int j = 0; j < maxHeight; j++)
                {
                    var particle = particles[i, j];
                    if (CheckPosition(i, ref j, particle))
                        continue;
                }
            }
            pictureBox1.Refresh();
        }

        private bool CheckPosition(int i, ref int j, Particle? particle)
        {
            if (particle is Particle p)
            {
                if (j + gravity < maxHeight)
                {
                    if (ParticleAlreadyExists(i, j, p))
                        return true;

                    MoveParticle(i, j, p);

                    j++;
                }
            }
            return false;
        }

        private bool ParticleAlreadyExists(int i, int j, Particle p)
        {
            if (particles[i, j + gravity] != null)
            {
                Draw(i, j, p.Brush);
                return true;
            }
            return false;
        }

        private void MoveParticle(int i, int j, Particle p)
        {
            ErasePreviousPosition(i, j);
            DrawNextPosition(i, j, p);
        }

        private void ErasePreviousPosition(int i, int j)
        {
            particles[i, j] = null;
            Draw(i, j, Brushes.White);
        }

        private void DrawNextPosition(int i, int j, Particle p)
        {
            particles[i, j + gravity] = p;
            Draw(i, j + gravity, p.Brush);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var particle = particles[e.X, e.Y] = new();

                if (particle is Particle p)
                    Draw(e.X, e.Y, p.Brush);
            }
        }

        private void Draw(int x, int y, Brush color)
        {
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.FillRectangle(color, x, y, w, w);
            }
            pictureBox1.Image = bm;
        }

        private void Resizing(object sender, EventArgs e)
        {
            LoadVariables();
        }

        private void Tick(object sender, EventArgs e)
        {
            MainLoop();
        }

        private void OnRendering(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }
    }
}