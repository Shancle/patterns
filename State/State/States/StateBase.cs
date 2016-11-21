using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using State.States;

namespace State
{
    public abstract class StateBase : IState
    {
        public virtual void PutMoney(CopyMachine copyMachine)
        {
            throw new InvalidOperationException("Слишком много денег");
        }

        public virtual void ChooseDevice(CopyMachine copyMachine)
        {
            throw new InvalidOperationException("Не время выбирать девайс");
        }

        public virtual void Print(CopyMachine copyMachine)
        {
            throw new InvalidOperationException();
        }

        public virtual void Stop(CopyMachine copyMachine)
        {
            Console.WriteLine("Не штатное завершение работы");
            copyMachine.State = new InitState();
        }
    }
}
