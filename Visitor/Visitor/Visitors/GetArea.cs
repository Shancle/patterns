using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Shapes;

namespace Visitor.Visitors
{
    class GetArea : IVisitor
    {
        public void Visit(Rectangle rectangle)
        {
            Console.WriteLine($"Площадь прямоугольника: {rectangle.SideA*rectangle.SideB}");
        }

        public void Visit(Triangle triangle)
        {
            var semiperimeter = (triangle.SideA + triangle.SideB + triangle.SideC)/2.0;
            var area =
                Math.Sqrt(semiperimeter*(semiperimeter - triangle.SideA)*(semiperimeter - triangle.SideB)*
                          (semiperimeter - triangle.SideC));
            Console.WriteLine($"Площадь треугольника: {area}");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine($"Площадь круга: {Math.PI*Math.Pow(circle.Radius, 2)}");
        }
    }
}
