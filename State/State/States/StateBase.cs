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
            copyMachine.State = new ErrorState();
        }

        public virtual void ChooseDevice(CopyMachine copyMachine)
        {
            copyMachine.State = new ErrorState();
        }

        public virtual void ChooseDocument(CopyMachine copyMachine)
        {
            copyMachine.State = new ErrorState();
        }

        public virtual void Print(CopyMachine copyMachine)
        {
            copyMachine.State = new ErrorState();
        }

        public virtual void Stop(CopyMachine copyMachine)
        {
            copyMachine.State = new ErrorState();
        }
    }
}
