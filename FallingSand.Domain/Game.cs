using System.Drawing;

namespace FallingSand.Domain
{
    public class Game
    {
        public List<Particle> Particles;
        public Render Render { get; }
        public Tool Tool { get; set; }

        public Game(Render render)
        {
            Render = render;
            Particles = render.Particles;
            Tool = Tool.Brush;
        }

        public void Tick()
        {
            foreach (var particle in Particles)
            {
                if (particle.Static)
                    continue;

                if (particle.OnGround(Render.Height - particle.Height))
                {
                    particle.UpdateStatus();
                    continue;
                }

                if (BottomColision(particle) is false)
                    particle.Move(Direction.Down, 1);
                else
                    particle.UpdateStatus();
            }
        }

        public void UseTool(int x, int y)
        {
            switch (Tool)
            {
                case Tool.Brush: BrushTool(x, y); break;

                case Tool.Eraser: EraserTool(x, y); break;

                default: throw new PalhaxotaException("sua palhaxota possui cores variadas");
            }
        }

        private void EraserTool(int x, int y)
        {
            var particleToRemove = Particles.FindAll(p => p.X == x && p.Y == y);
            RemoveParticles(particleToRemove);
        }
        private void BrushTool(int x, int y)
        {
            Particle particle = new(x, y, 4, 4, Brushes.Black);
            AddParticle(particle);
        }

        private bool BottomColision(Particle particle)
        {
            return Particles.Any(p => CollisionDirection(particle, p) is Direction.Down);
        }

        private static Direction CollisionDirection(Particle particle, Particle particleAnom)
        {
            if (!Colided(particle, particleAnom))
                return Direction.None;

            return particle.GetDirection(particleAnom);
        }

        private static bool Colided(Particle particle, Particle particleAnom)
        {
            return particleAnom != particle &&
                   particle.X < particleAnom.X + particleAnom.Width &&
                   particle.X + particle.Width > particleAnom.X &&
                   particle.Y < particleAnom.Y + particleAnom.Height &&
                   particle.Y + particle.Height > particleAnom.Y;
        }

        private void AddParticle(Particle particle)
        {
            if (!Particles.Any(p => Colided(particle, p)))
                Particles.Add(particle);
        }

        private void RemoveParticles(List<Particle> particleToRemove)
        {
            
        }
    }
    public enum Tool
    {
        Brush = 'b',
        Eraser = 'e'
    }
}