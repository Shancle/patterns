using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    class ErrorState : StateBase
    {
        public override void PutMoney(CopyMachine copyMachine)
        {
            throw new InvalidOperationException("Слишком много денег");
        }

        public override void ChooseDevice(CopyMachine copyMachine)
        {
            throw new InvalidOperationException("Не время выбирать девайс");
        }

        public override void ChooseDocument(CopyMachine copyMachine)
        {
            throw new InvalidOperationException("Не время выбирать документ");
        }

        public override void Print(CopyMachine copyMachine)
        {
            throw new InvalidOperationException();
        }

        public override void Stop(CopyMachine copyMachine)
        {
            Console.WriteLine("Не штатное завершение работы");
            copyMachine.State = new InitState();
        }
    }
}
