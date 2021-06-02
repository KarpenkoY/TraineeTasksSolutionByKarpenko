using System.Collections.Generic;

namespace Shapes
{
    class ShapesApp
    {
        static void Main(string[] args)
        {
            var side = 1.1234D;
            var radius = 1.1234D;
            var bas = 5D;
            var height = 2D;

            var shapes = new List<Shape>
            { 
                new Square(side),
                new Circle(radius),
                new Triangle(bas, height) 
            };

            shapes.Sort();
        }
    }
}
