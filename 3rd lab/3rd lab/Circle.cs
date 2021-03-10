using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_lab
{
    class Circle
    {
        public double Radius { get;}
        public Circle(double r)
        {
            if (r <= 0)
            {
                throw new ArgumentException("Radius can't be 0 or less than 0");
            }
            Radius = r;
        }
        // S = π*r^2
        public double Square()
        {
            return Math.PI * Radius * Radius;
        }
        // P = π*2r
        public double Perimeter()
        {
            return Math.PI * 2 * Radius;
        }
    }
}
