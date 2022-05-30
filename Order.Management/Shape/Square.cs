using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management.Shape
{
    class Square : Shape
    {
        public Square(decimal price) : base("Square", price,  ShapeType.Square) { }
    }
}
