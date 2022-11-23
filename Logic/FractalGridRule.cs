using BirdLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class FractalGridRule
    {
        public List<Grid<bool>> SourceGrids { get; set; }
        public Grid<bool> DestinationGrid { get; set; }
    }
}
