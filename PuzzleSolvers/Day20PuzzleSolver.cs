using AOC;
using AOC2017.Logic;
using AOC2017.Models;
using AOC2017.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day20PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] lines = InputFilesHelper.GetInputFileLines("day20.txt");

            List<ParticleData> particles = ParticleDataParser.ParseRows(lines);

            var particlesByMaxAccelerationThanVelocity = particles.OrderBy(particle => GetMaxVector3Value(particle.Acceleration))

                 .ThenBy(particle => GetMaxVector3Value(particle.Velocity))
                 .Select((particle) =>
                 new
                 {
                     Index = particle.Index,
                     MaxAcceleration = GetMaxVector3Value(particle.Acceleration),
                     MaxVelocity = GetMaxVector3Value(particle.Velocity)
                 });


            return particlesByMaxAccelerationThanVelocity.First().Index.ToString() ;
        }

        private int GetMaxVector3Value(Vector3 acceleration)
        {
            int x = (int)Math.Abs(acceleration.X);
            int y = (int)Math.Abs(acceleration.Y);
            int z = (int)Math.Abs(acceleration.Z);

            return (new[] { x, y, z }).Max();

        }

        public string SolvePuzzlePart2()
        {
            string[] lines = InputFilesHelper.GetInputFileLines("day20.txt");

            List<ParticleData> particles = ParticleDataParser.ParseRows(lines);
            var simulator = new ParticleSimulator(particles);

            int particlesLeft = simulator.RumSimulation(1000);

            return particlesLeft.ToString();
        }
    }
}
