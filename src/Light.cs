using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emgu_Test
{
	public class Light : IComparable<Light>
	{
		public int Number { get; set; }
		public Point Position { get; set; }
		public Point ScalePos { get; set; }
		public int Diameter { get; set; }

        /// <summary>
        /// Compare Light blob diameters.
        /// </summary>
        /// <param name="B"></param>
        /// <returns>1 if this diam is greater, -1 if B diam is greater, 0 if equal</returns>
		public int CompareTo(Light B)
        {
            if (B == null)
            // If B is null, this is greater.
            {
                return 1;
            }
            else
            {
                // If B is not null, compare the diameters
                if (this.Diameter > B.Diameter)
                {
                    return 1;
                }
                else if (B.Diameter > this.Diameter)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
