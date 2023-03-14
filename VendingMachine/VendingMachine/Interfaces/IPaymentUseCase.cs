using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IPaymentUseCase
    {
        public string Name { get; }

        public string Description { get; }

        public bool CanExecute { get; }

        public void Execute(decimal price);
    }
}
