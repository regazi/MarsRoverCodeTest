using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCodeTest
{
    public class Grid
    {
        internal int X { get; set; } //boundary X
        internal int Y { get; set; } //boundary Y
       
        public Grid(int[] boundaries)
        {
            X = boundaries[0];
            Y = boundaries[1];                   
        }
        public Grid(int boundaryXY)
        {
            X = boundaryXY;
            Y = boundaryXY;
        }

    }
               

}
