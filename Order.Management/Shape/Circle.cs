using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management.Shape
{
    class Circle : Shape
    {
        public Circle(decimal price) : base("Circle", price, ShapeType.Circle) { }
    }
}
