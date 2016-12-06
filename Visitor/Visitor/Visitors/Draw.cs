using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Shapes;

namespace Visitor.Visitors
{
    class Draw : IVisitor
    {
        public void Visit(Rectangle rectangle)
        {
            Console.WriteLine($"Нарисован прямоугольник с центром в {rectangle.Center}");
        }

        public void Visit(Triangle triangle)
        {
            Console.WriteLine($"Нарисован треугольник с центром в {triangle.Center}");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine($"Нарисован круг с центром в {circle.Center}");
        }
    }
}
