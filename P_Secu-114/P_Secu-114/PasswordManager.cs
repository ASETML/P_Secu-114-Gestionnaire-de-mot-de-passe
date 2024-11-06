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
            string password = EncryptionManager.Encrypt(Console.ReadLine());
            string username = Console.ReadLine();
            string url = Console.ReadLine();

            _passwordList.Add(new Entry(password, username, url));
        }

        public static void UpdateEntry()
        {

        }

        public static void RemoveEntry(Entry entry)
        {
            _passwordList.Remove(entry);
        }
    }
}
