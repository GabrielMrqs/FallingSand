namespace FallingSand
{
    partial class GameView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.FPScounter = new System.Windows.Forms.Timer(this.components);
            this.FPS = new System.Windows.Forms.Label();
            this.Particles = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1264, 681);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Tick);
            // 
            // FPScounter
            // 
            this.FPScounter.Interval = 1000;
            this.FPScounter.Tick += new System.EventHandler(this.FpsTick);
            // 
            // FPS
            // 
            this.FPS.AutoSize = true;
            this.FPS.Location = new System.Drawing.Point(12, 9);
            this.FPS.Name = "FPS";
            this.FPS.Size = new System.Drawing.Size(26, 15);
            this.FPS.TabIndex = 1;
            this.FPS.Text = "FPS";
            // 
            // Particles
            // 
            this.Particles.AutoSize = true;
            this.Particles.Location = new System.Drawing.Point(12, 31);
            this.Particles.Name = "Particles";
            this.Particles.Size = new System.Drawing.Size(51, 15);
            this.Particles.TabIndex = 2;
            this.Particles.Text = "Particles";
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Particles);
            this.Controls.Add(this.FPS);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Resizing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnRendering);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer FPScounter;
        private Label FPS;
        private Label Particles;
    }
}