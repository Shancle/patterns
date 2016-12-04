using System;
using NUnit.Framework;
using State.States;

namespace State
{
    class CopyCachine_should
    {
        [Test]
        public void ThrowException()
        {
            var copyMachine = new CopyMachine();
            copyMachine.Print();
            Assert.True(copyMachine.State is ErrorState);
            Assert.Throws<InvalidOperationException>(() => copyMachine.ChooseDocument());
        }

        [Test]
        public void DoesNotThrowException()
        {
            var copyMachine = new CopyMachine();
            Assert.DoesNotThrow(() =>
            {
                copyMachine.PutMoney();
                copyMachine.ChooseDevice();
                copyMachine.ChooseDocument();
                copyMachine.Print();
                copyMachine.Stop();
            });
        }
    }
}
