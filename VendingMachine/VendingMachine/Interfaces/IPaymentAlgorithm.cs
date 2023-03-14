using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IPaymentAlgorithm
    {
        public string Name { get; }

        public void Run(decimal price);

    }
}
