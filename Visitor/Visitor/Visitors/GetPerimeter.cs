using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Shapes;

namespace Visitor.Visitors
{
    class GetPerimeter : IVisitor
    {
        public void Visit(Rectangle rectangle)
        {
            Console.WriteLine($"Перимитер прямоугольника: {2*(rectangle.SideB+rectangle.SideA)}");
        }

        public void Visit(Triangle triangle)
        {
            Console.WriteLine($"Перимитер треугольника: {triangle.SideA + triangle.SideB + triangle.SideC}");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine($"Перимитер круга: {2 * Math.PI * circle.Radius}");
        }
    }
}
