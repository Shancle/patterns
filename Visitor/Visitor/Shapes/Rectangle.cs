using System.Drawing;
using Visitor.Visitors;

namespace Visitor.Shapes
{
    public class Rectangle : ShapeBase
    {
        public int SideA { get; set; }
        public int SideB { get; set; }

        public Rectangle(Point center, int sideA, int sideB)
        {
            Center = center;
            SideA = sideA;
            SideB = sideB;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}