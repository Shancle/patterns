using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    class ReadyToPrintState : StateBase
    {
        public override void Print(CopyMachine copyMachine)
        {
            Console.WriteLine("Начало печати");
            Console.WriteLine(copyMachine.CurrentDevice?.ReadInfo());
            copyMachine.State = new ChooseDeviceState();
        }
    }
}
