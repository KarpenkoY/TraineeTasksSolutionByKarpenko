using System;

namespace Shapes
{
    public abstract class Shape : IComparable
    {
        public double Area { get; set; }

        public int CompareTo(object obj)
        {
            Shape shape = obj as Shape;

            if (shape != null)
            {
                return Area.CompareTo(shape.Area);
            }
            else
            {
                throw new Exception("Uncomparable objects");
            }
        }
    }

    public class Square : Shape
    {
        public double Side { get; set; }
        public Square(double side)
        {
            Side = side;
            Area = side * side;
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Width   = width;
            Height  = height;
            Area    = width * height;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(double bas, double height)
        {
            Base    = bas;
            Height  = height;
            Area    = bas * height / 2;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius  = radius;
            Area    = radius * Math.PI;
        }
    }
}
