using Visitor.Shapes;

namespace Visitor.Visitors
{
    public interface IVisitor
    {
        void Visit(Rectangle rectangle);
        void Visit(Triangle triangle);
        void Visit(Circle circle);
    }
}