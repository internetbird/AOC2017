using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class ParticleData
    {
        public int Index { get; set; }
        public Vector3 Position {get; set;}
        public Vector3 Velocity {get; set;}
        public Vector3 Acceleration { get; set; }

    }
}
