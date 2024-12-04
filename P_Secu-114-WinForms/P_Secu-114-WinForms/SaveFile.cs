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
            string passwordListJson = JsonSerializer.Serialize(PasswordManager.PasswordList);
            string encryptedPasswordListJson = EncryptionManager.Encrypt(passwordListJson);

            List<string> passwordList = new List<string>();
            passwordList.Add(EncryptionManager.Encrypt(MasterPassword.Key));
            passwordList.Add(encryptedPasswordListJson);

            string passwordPasswordListJson = JsonSerializer.Serialize(passwordList);
            string encryptedPasswordPasswordListJson = EncryptionManager.Encrypt(passwordPasswordListJson);

            File.WriteAllText(savePath, encryptedPasswordPasswordListJson);
        }

        public static void ReadEntries(string inputMasterPassword)
        {
            int sleep = 1;
            try
            {
                string fileContent = File.ReadAllText(savePath);
                string decryptedFileContent = EncryptionManager.Decrypt(fileContent);

                List<string> passwordList = JsonSerializer.Deserialize<List<string>>(decryptedFileContent);

                MasterPassword.Key = inputMasterPassword;

                if (EncryptionManager.Encrypt(inputMasterPassword) != passwordList[0])
                {
                    Random random = new Random();
                    sleep = (int)Math.Round(random.NextDouble() * (random.NextDouble() * 5000) + 250);
                    Thread.Sleep(sleep);
                    throw new WrongPasswordException("Le mot de passe n'est pas correct !");
                }

                string encryptedPassword = EncryptionManager.Decrypt(passwordList[1]);
                PasswordManager.PasswordList = JsonSerializer.Deserialize<List<Entry>>(encryptedPassword);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(WrongPasswordException))
                {
                    MessageBox.Show("Vous vous êtes trompés de mot de passe : l'application va s'eteindre \n " + sleep);
                    Application.Exit();
                }
            }
        }
    }
}
