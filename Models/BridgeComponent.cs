using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class BridgeComponent
    {
        private List<int> _ports = new List<int>();
        public List<int> Ports => new List<int>(_ports);

        public BridgeComponent(int port1, int port2)
        {
            _ports.Add(port1);
            _ports.Add(port2);
        }

        public bool HasMatchForPort(int port)
        {
            return _ports.Any(p => p == port);
        }

        public BridgeComponent Clone()
        {
            return new BridgeComponent(_ports[0], _ports[1]);
        }

        public int GetOtherPort(int currentPort)
        {
            int portIndex = _ports.IndexOf(currentPort);
            return portIndex == 0 ? _ports[1] : _ports[0];
        }

       
    }
}
