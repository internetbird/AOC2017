using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class ParticleSimulator
    {
        private List<ParticleData> _particles;

        public ParticleSimulator(List<ParticleData> particles)
        {
            _particles = particles;
        }

        public int RumSimulation(int numOfSteps)
        {
            while(numOfSteps > 0)
            {
                CalculateNextStep();
                Console.WriteLine($"Particles Left: {_particles.Count}");
                numOfSteps--;
            }

            return _particles.Count;
        }

        private void CalculateNextStep()
        {
            foreach (ParticleData particle in _particles)
            {
                UpdateParticleData(particle);
            }

            RemoveCollidingParticles();
        }

        private void RemoveCollidingParticles()
        {
            var particlesPositionDict = new Dictionary<string, List<int>>();

            //First we build the positions dictionary
            foreach (ParticleData particle in _particles)
            {
                var key = particle.Position.ToString();

                if (!particlesPositionDict.ContainsKey(key))
                {
                    particlesPositionDict.Add(key, new List<int>());
                }

                particlesPositionDict[key].Add(particle.Index);
            }

            //Then we find the positions that have 2 or more particles and remove them
            var collistionPositions = particlesPositionDict.Where(kvp => kvp.Value.Count > 1);
            foreach (var position in collistionPositions)
            {
                _particles.RemoveAll(particle => position.Value.Contains(particle.Index));
            }
        }

        private void UpdateParticleData(ParticleData particle)
        {
            var newVelocityVector = new Vector3
            {
                X = particle.Velocity.X + particle.Acceleration.X,
                Y = particle.Velocity.Y + particle.Acceleration.Y,
                Z = particle.Velocity.Z + particle.Acceleration.Z
            };

            particle.Velocity = newVelocityVector;

            var newPositionVector = new Vector3
            {
                X = particle.Position.X + particle.Velocity.X,
                Y = particle.Position.Y + particle.Velocity.Y,
                Z = particle.Position.Z + particle.Velocity.Z
            };

            particle.Position = newPositionVector;
        }
    }
}
