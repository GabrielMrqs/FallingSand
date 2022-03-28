using FallingSand.Domain;
using System.Drawing;
using System.Linq;

namespace FallingSand
{
    public partial class GameView : Form
    {
        private Game Game;
        private Render Render;
        public GameView()
        {
            InitializeComponent();
            Render = new();
            Game = new(Render);
            LoadVariables();
        }

        private void LoadVariables()
        {
            Render.UpdateScreenSize(pictureBox.Width, pictureBox.Height);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Particle particle = new(e.X, e.Y, 20, 20, Brushes.Black);
                Game.AddParticle(particle);
            }
        }
        private void Resizing(object sender, EventArgs e)
        {
            LoadVariables();
        }
        private void Tick(object sender, EventArgs e)
        {
            Text = Render.Height.ToString();

            Game.Tick();

            pictureBox.Image = Render.Draw();
        }
        private void OnRendering(object sender, PaintEventArgs e)
        {
            Timer.Start();
        }
    }
}