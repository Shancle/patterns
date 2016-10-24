using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class BMWFactory : ICarFactory
    {
        public IBody CreateBody() => new BMWBody();

        public IBumper CreateBumper() => new BMWBumper();

        public IEngine CreatEngine() => new BMWEngine();

        public IHeadlights CreateHeadlights() => new BMWHeadlights();

        public IInterior CreateInterior() => new BMWInterior();
    }
}
