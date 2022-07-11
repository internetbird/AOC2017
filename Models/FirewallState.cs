using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class FirewallState
    {
        public List<ScannerPosition> ScannerPositions { get; set; }

        public FirewallState()
        {
            ScannerPositions = new List<ScannerPosition>();
        }


        public ScannerPosition GetScannerPositionForLayer(int index)
        {
            return ScannerPositions.FirstOrDefault(position => position.LayerIndex == index);
        }
    }
}
