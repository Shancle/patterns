using NUnit.Framework;
using FluentAssertions;

namespace AbstractFactory.Tests
{
    class Car_Factory_should
    {
        [Test]
        public void CreateBodyForBMW()
        {
            var factory = new BMWFactory();
            var body = factory.CreateBody();

            body.Name.Should().BeEquivalentTo("BMW body");
        }

        [Test]
        public void CreateInteriorForBMW()
        {
            var factory = new BMWFactory();
            var interior = factory.CreateInterior();

            interior.Name.Should().BeEquivalentTo("BMW interior");
        }

        [Test]
        public void CreateHeadlightsForAUDI()
        {
            var factory = new AUDIFactory();
            var headlights = factory.CreateHeadlights();

            headlights.Name.Should().BeEquivalentTo("AUDI headlights");
        }

        [Test]
        public void CreateEngineForAUDI()
        {
            var factory = new AUDIFactory();
            var engine = factory.CreatEngine();

            engine.Name.Should().BeEquivalentTo("AUDI engine");
        }
    }
}
