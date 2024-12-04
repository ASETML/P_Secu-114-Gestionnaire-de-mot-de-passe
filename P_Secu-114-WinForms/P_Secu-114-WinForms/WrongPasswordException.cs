using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114_WinForms
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException(string message): base(message)
        {

        }
    }
}
