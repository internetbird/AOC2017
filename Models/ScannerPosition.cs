﻿using BirdLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class ScannerPosition
    {
        public int LayerIndex { get; set; }
        public int PositionIndex { get; set; }
        public int LayerRange { get; set; }
        public VerticalDirection MoveDirection { get; set; }
    }
}
