namespace State
{
    public interface IState
    {
        void PutMoney(CopyMachine copyMachine);
        void ChooseDevice(CopyMachine copyMachine);
        void Print(CopyMachine copyMachine);
        void Stop(CopyMachine copyMachine);
    }
}