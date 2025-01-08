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
    /// <summary>
    /// Sauvegarder et récupérer les données du fichier de sauvegarde
    /// </summary>
    public static class SaveFile
    {
        const string saveFile = "saveFile.json";
        const string savePath = "password";
        const string fileExtension = ".txt";
        const string configFile = "config.txt";

        /// <summary>
        /// Sauvegarde les entrées
        /// </summary>
        public static void SaveEntries()
        {
            //Crée le dossier password si nécessaire
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            //Crée le fichier de configuration si nécessaire et y écrit le Master password chiffré
            if (!File.Exists(configFile))
            {
                File.WriteAllText(configFile, EncryptionManager.Encrypt(MasterPassword.Key));
            }

            //Crée les fichiers de mots de passes
            foreach (Entry entry in PasswordManager.PasswordList)
            {
                File.WriteAllText(Path.Combine(savePath, entry.Title + fileExtension), JsonSerializer.Serialize(entry));
            }
        }

        /// <summary>
        /// Récupère les mots de passes du fichier de sauvegardes
        /// </summary>
        /// <param name="inputMasterPassword">Le mot de passe que l'utilisateur a rentrer</param>
        /// <exception cref="WrongPasswordException">Lance une exception si le mot de passe n'est pas correct</exception>
        public static void ReadEntries(string inputMasterPassword)
        {
            try
            {
                MasterPassword.Key = inputMasterPassword;

                //Si le fichier de configuration n'est pas présent, on le crée
                if (!File.Exists(configFile))
                {
                    SaveEntries();
                }
                //Si le mot de passe est correct
                if (EncryptionManager.Encrypt(inputMasterPassword) == File.ReadAllText(configFile)) ;
                {
                    string[] files = Directory.GetFiles(savePath); //Récupère les noms des fichiers

                    //Rempli la liste de mots de passes
                    foreach (string file in files)
                    {
                        PasswordManager.PasswordList.Add(JsonSerializer.Deserialize<Entry>(File.ReadAllText(file)));
                    }
                    return;
                }
                throw new WrongPasswordException("Mauvais mot de passe");
            }
            catch (Exception ex)
            {
                //Si le mot de passe n'est pas correct
                if (ex.GetType() == typeof(WrongPasswordException))
                {
                    //On affiche un pop-up
                    string message = "Vous vous êtes trompés de mot de passe : l'application va s'éteindre";
                    string caption = "Erreur dans le mot de passe";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);

                    //On quitte l'application
                    Application.Exit();
                }
            }
        }
    }
}
