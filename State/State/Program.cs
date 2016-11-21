using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        public static void Main(string[] args)
        {
            var copyMachine = new CopyMachine();
            copyMachine.PutMoney();
            copyMachine.ChooseDevice();
            copyMachine.Print();
            copyMachine.Stop();
        }
    }
}
