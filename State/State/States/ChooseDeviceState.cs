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
            copyMachine.State = new ReadyToPrintState();
        }

        public override void Stop(CopyMachine copyMachine)
        {
            Console.WriteLine("Завершение работы");
            Console.WriteLine("Выдаём сдачу");
            copyMachine.State = new InitState();
        }
    }
}
