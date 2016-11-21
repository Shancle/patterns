using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    class InitState : StateBase
    {
        public override void PutMoney(CopyMachine copyMachine)
        {
            Console.WriteLine("Получена некоторая сумма");
            copyMachine.State = new ChooseDeviceState();
        }
    }
}
