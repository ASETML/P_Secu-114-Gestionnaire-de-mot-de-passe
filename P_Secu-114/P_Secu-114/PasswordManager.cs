using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114
{
    /// <summary>
    /// Create, delete, show entrys
    /// </summary>
    public static class PasswordManager
    {
        private static List<Entry> _passwordList= new List<Entry>();

        public static void ShowEntryList()
        {
            foreach (Entry entry in _passwordList)
            {
                string password = entry.Password;
                EncryptionManager.Decrypt(password);
            }
        }

        public static void AddEntry()
        {

        }

        public static void RemoveEntry()
        {

        }
    }
}
