using System.Drawing;
using Visitor.Shapes;
using Visitor.Visitors;

namespace Visitor
{
    public class Circle : ShapeBase
    {
        public int Radius { get; set; }
        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}