using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electtodes_Potentials
{
    public class Electrod
    {
        public Electrod(int posx, int posy, double x, double y, double voltage)
        {
            this.x = x;
            this.y = y;
            this.posx = posx;
            this.posy = posy;
            this.voltage = voltage;
        }

        public double x;
        public double y;
        public int posx;
        public int posy; 
        public double voltage;
    }
}
