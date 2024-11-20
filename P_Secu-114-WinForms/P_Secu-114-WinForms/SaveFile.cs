using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;

namespace P_Secu_114_WinForms
{
    public static class SaveFile
    {
        public static void SaveEntries(string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(PasswordManager.PasswordList));
        }

        public static void ReadEntries(string path)
        {
            try
            {
                PasswordManager.PasswordList = JsonSerializer.Deserialize<List<Entry>>(File.ReadAllText(path));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
