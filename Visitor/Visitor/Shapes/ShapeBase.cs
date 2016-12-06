using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Visitors;

namespace Visitor.Shapes
{
    public abstract class ShapeBase
    {
        public Point Center;
        public abstract void Accept(IVisitor visitor);
    }
}
