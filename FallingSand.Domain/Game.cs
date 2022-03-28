namespace FallingSand.Domain
{
    public class Game
    {
        public List<Particle> Particles;

        public Render Render { get; }

        public Game(Render render)
        {
            Render = render;
            Particles = render.Particles;
        }

        public void Tick()
        {
            foreach (var particle in Particles)
            {
                if (particle.OnGround(Render.Height - particle.Height))
                    continue;

                if (!Particles.Any(p =>
                {
                    var colision = CollisionDirection(particle, p);

                    if (colision is Direction.Down)
                        return true;

                    return false;
                }))
                    particle.Move(Direction.Down);
            }
        }

        private static Direction CollisionDirection(Particle particle, Particle particleAnom)
        {
            if (!Colided(particle, particleAnom))
            {
                return Direction.None;
            }
            if (particle.Y > particleAnom.Y)
            {
                return Direction.Up;
            }
            if (particle.Y < particleAnom.Y)
            {
                return Direction.Down;
            }
            if (particle.X < particleAnom.X)
            {
                return Direction.Right;
            }
            if (particle.X > particleAnom.X)
            {
                return Direction.Left;
            }

            throw new Exception("Sexo Total Exception");
        }

        private static bool Colided(Particle particle, Particle particleAnom)
        {
            return particleAnom != particle &&
                               particle.X < particleAnom.X + particleAnom.Width &&
                               particle.X + particle.Width > particleAnom.X &&
                               particle.Y < particleAnom.Y + particleAnom.Height &&
                               particle.Y + particle.Height > particleAnom.Y;
        }

        public void AddParticle(Particle particle)
        {
            if (!Particles.Any(p => Colided(particle, p)))
                Particles.Add(particle);
        }
    }
}