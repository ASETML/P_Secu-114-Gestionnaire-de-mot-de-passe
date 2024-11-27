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
        const string savePath = "a";

        public static void SaveEntries()
        {
            File.WriteAllText(savePath, JsonSerializer.Serialize(PasswordManager.PasswordList));
        }

        public static void ReadEntries()
        {
            try
            {
                PasswordManager.PasswordList = JsonSerializer.Deserialize<List<Entry>>(File.ReadAllText(savePath));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
