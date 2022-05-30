using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management.Shape
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ShapeType Type { get; set; }
       
        protected Shape(string name, decimal price, ShapeType type)
        {
            Name = name;
            Price = price;
            Type = type;
        }

        public static string[] GetShapes()
        {
            return Enum.GetNames(typeof(ShapeType));
        }
    }

    public enum Color
    {
        Red = 1,
        Blue = 2,
        Yellow = 3
    }

    public enum ShapeType
    {
        Square = 1,
        Triangle = 2,
        Circle = 3
    }

}
