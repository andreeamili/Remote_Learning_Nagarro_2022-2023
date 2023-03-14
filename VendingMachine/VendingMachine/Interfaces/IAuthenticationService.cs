using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IAuthenticationService
    {
        public bool IsUserAuthenticated { get;}
        public void Login(string password);

        public void Logout();
    }
}
