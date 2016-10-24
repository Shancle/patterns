using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class AUDIFactory : ICarFactory
    {
        public IBody CreateBody() => new AUDIBody();

        public IBumper CreateBumper() => new AUDIBumper();

        public IEngine CreatEngine() => new AUDIEngine();

        public IHeadlights CreateHeadlights() => new AUDIHeadlights();

        public IInterior CreateInterior() => new AUDIInterior();
    }
}
