using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114_WinForms
{
    public static class Helpers
    {
        public static string HidePassword(int length)
        {
            string hiddenPassword = "";

            for (int i = 0; i < length; i++)
            {
                hiddenPassword += '•';
            }

            return hiddenPassword;
        }
    }
}
