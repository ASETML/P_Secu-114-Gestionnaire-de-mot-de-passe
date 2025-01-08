using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace P_Secu_114_WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            MasterPassword.Key = "etml";
            PasswordManager.PasswordList.Add(new Entry("1", "1", "1", "1"));
            PasswordManager.PasswordList.Add(new Entry("2", "2", "1", "1"));
            PasswordManager.PasswordList.Add(new Entry("3", "3", "1", "1"));
            PasswordManager.PasswordList.Add(new Entry("4", "4", "1", "1"));
            PasswordManager.PasswordList.Add(new Entry("5", "5", "1", "1"));
            PasswordManager.PasswordList.Add(new Entry("6", "6", "1", "1"));
            PasswordManager.PasswordList.Add(new Entry("7", "7", "1", "1"));
            SaveFile.SaveEntries();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}