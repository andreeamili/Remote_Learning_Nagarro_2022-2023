using System;
using System.Collections.ObjectModel;

namespace RemoteLearning.Geometrix.NoOcp.ShapeModel
{
    internal class GeometricShapes : Collection<object>
    {
        public double CalculateArea()
        {
            double area = 0;

            foreach (object shape in Items)
            {
                switch (shape)
                {
                    case Rectangle rectangle:
                        area += rectangle.Width * rectangle.Height;
                        break;

                    case Circle circle:
                        area += circle.Radius * circle.Radius * Math.PI;
                        break;
                    case Triangle triangle:
                        double s = (triangle.SideOne + triangle.SideTwo + triangle.SideThree) / 2;
                        area += Math.Sqrt(s * (s - triangle.SideOne) * (s - triangle.SideTwo) * (s - triangle.SideThree));
                        break;
                    default:
                        throw new Exception("Unknown shape.");
                }
            }

            return area;
        }
    }
}