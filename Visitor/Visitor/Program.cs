using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Shapes;
using Visitor.Visitors;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new ShapeBase[]
            {
                new Circle(new Point(0, 0), 1), new Shapes.Rectangle(new Point(0, 0), 3, 4),
                new Triangle(new Point(0, 0), 3, 4, 5)
            };
            var visitors = new IVisitor[] {new Draw(), new GetArea(), new GetPerimeter()};
            foreach (var shape in shapes)
            {
                foreach (var visitor in visitors)
                    shape.Accept(visitor);
                Console.WriteLine();
            }
        }
    }
}
