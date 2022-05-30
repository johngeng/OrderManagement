using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management.Shape
{
    class Triangle : Shape
    {
        public Triangle(decimal price) : base("Triangle", price, ShapeType.Triangle) { }
    }
}
