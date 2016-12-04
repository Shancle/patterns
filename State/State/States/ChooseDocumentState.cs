using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    class ChooseDocumentState : StateBase
    {
        public override void Stop(CopyMachine copyMachine)
        {
            Console.WriteLine("Завершение работы");
            Console.WriteLine("Выдаём сдачу");
            copyMachine.State = new InitState();
        }

        public override void ChooseDocument(CopyMachine copyMachine)
        {
            copyMachine.CurrentDocument = copyMachine.CurrentDevice?.GetDocument("123"); // типо как то выбрали документ
            Console.WriteLine($"Выбран документ: {copyMachine.CurrentDocument}");
            copyMachine.State = new ReadyToPrintState();
        }
    }
}
