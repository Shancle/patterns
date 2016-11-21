using System;
using NUnit.Framework;

namespace State
{
    class CopyCachine_should
    {
        [Test]
        public void ThrowException()
        {
            var copyMachine = new CopyMachine();
            Assert.Throws<InvalidOperationException>(() => copyMachine.Print());
            copyMachine.PutMoney();
            copyMachine.ChooseDevice();
            Assert.Throws<InvalidOperationException>(() => copyMachine.PutMoney());
        }

        [Test]
        public void DoesNotThrowException()
        {
            var copyMachine = new CopyMachine();
            Assert.DoesNotThrow(() =>
            {
                copyMachine.PutMoney();
                copyMachine.ChooseDevice();
                copyMachine.Print();
                copyMachine.Stop();
            });
        }
    }
}
