using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double SideOne { get; set; }

        public double SideTwo { get; set; }

        public double SideThree { get; set; }

        public double CalculateArea()
        {
            double semiperimeter = (SideOne + SideTwo + SideThree) / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - SideOne) * (semiperimeter - SideTwo) * (semiperimeter - SideThree));
        }
    }
}
