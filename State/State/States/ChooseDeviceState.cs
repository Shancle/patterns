using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    class ChooseDeviceState : StateBase
    {
        public override void ChooseDevice(CopyMachine copyMachine)
        {
            copyMachine.CurrentDevice = null; // типо как то выбрали девайс
            Console.WriteLine($"Выбран device: {copyMachine.CurrentDevice}");
            copyMachine.State = new ChooseDocumentState();
        }
    }
}
