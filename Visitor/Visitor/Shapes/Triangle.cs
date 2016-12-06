using System.Drawing;
using Visitor.Shapes;
using Visitor.Visitors;

namespace Visitor
{
    public class Triangle : ShapeBase
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }

        public Triangle(Point center, int sideA, int sideB, int sideC)
        {
            Center = center;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}