using FallingSand.Domain;

namespace FallingSand
{
    public partial class GameView : Form
    {
        private Game Game { get; }
        private Render Render { get; }
        private int Counter { get; set; }
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
                Game.UseTool(e.X,e.Y);
            }
        }

        private void Resizing(object sender, EventArgs e)
        {
            LoadVariables();
        }

        private void Tick(object sender, EventArgs e)
        {
            Game.Tick();

            pictureBox.Image = Render.Draw();

            Counter++;

            Particles.Text = $"{Game.Particles.Count}";
        }

        private void OnRendering(object sender, PaintEventArgs e)
        {
            Timer.Start();
            FPScounter.Start();
        }

        private void FpsTick(object sender, EventArgs e)
        {            
            FPS.Text = Counter.ToString();
            Counter = 0;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            Game.Tool = (Tool)e.KeyChar;
        }

    }
}