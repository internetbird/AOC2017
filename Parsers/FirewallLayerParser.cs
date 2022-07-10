using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Parsers
{
    public static class FirewallLayerParser
    {
        public static FirewallLayer ParseLine(string line)
        {
            var layer = new FirewallLayer();
            string[] lineParts = line.Split(new char[] { ':' });

            layer.Depth = int.Parse(lineParts[0].Trim());
            layer.Range = int.Parse((lineParts[1].Trim()));

            return layer;
        }
    }
}
