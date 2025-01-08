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
        const string savePath = "saveFile.json";
        /// <summary>
        /// Sauvegarde les mots de passes
        /// </summary>
        public static void SaveEntries()
        {
            //On serialise la liste de mot de passe en json
            string passwordListJson = JsonSerializer.Serialize(PasswordManager.PasswordList);
            //On chiffre la liste de mot de passe
            string encryptedPasswordListJson = EncryptionManager.Encrypt(passwordListJson);

            //On crée une liste qui contiendra le Master password chiffré et la liste de mot de passe
            List<string> passwordList = new List<string>();
            //On ajoute le Master password chiffré à la liste
            passwordList.Add(EncryptionManager.Encrypt(MasterPassword.Key));
            //On ajoute la liste de mots de passes chiffrés à la liste
            passwordList.Add(encryptedPasswordListJson);

            //On serialise la liste en json
            string passwordPasswordListJson = JsonSerializer.Serialize(passwordList);

            //On écrit le json de la liste dans le fichier de sauvegarde
            File.WriteAllText(savePath, passwordPasswordListJson);
        }

        /// <summary>
        /// Récupère les mots de passes du fichier de sauvegardes
        /// </summary>
        /// <param name="inputMasterPassword">Le mot de passe que l'utilisateur a rentrer</param>
        public static void ReadEntries(string inputMasterPassword)
        {
            int sleep = 1; //Le délai si le mot de passe entré n'est pas correct
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //L'emplacement de l'exécutable

            //Si l'utilisateur n'a pas entré de mot de passe, on en redemande un
            if (inputMasterPassword == "")
            {
                Application.Restart();
            }
            //Si le fichier de sauvegarde n'existe pas, on le crée, on considère que le mot de passe entré est le nouveau Master password
            else if (!File.Exists(Path.Combine(path, savePath)))
            {
                File.Create(Path.Combine(path, savePath)).Close();
                MasterPassword.Key = inputMasterPassword;
                SaveEntries();
            }
            //Si le fichier existe
            else
            {
                try
                {
                    MasterPassword.Key = inputMasterPassword; //Le mot de passe entré est le nouveau Master password
                    string fileContent = File.ReadAllText(savePath); //Le contenu du fichier

                    List<string> passwordList = JsonSerializer.Deserialize<List<string>>(fileContent); //On récupère la liste qui contient le Master password et la liste des mots de passes
                    
                    //Si le mot de passe entré n'est pas correct
                    if (EncryptionManager.Encrypt(inputMasterPassword) != passwordList[0])
                    {
                        //On ajoute un délai aléatoire
                        Random random = new Random();
                        sleep = (int)Math.Round(random.NextDouble() * (random.NextDouble() * 5000) + 250);
                        Thread.Sleep(sleep);
                        //On lance une exception
                        throw new WrongPasswordException("Le mot de passe n'est pas correct !");
                    }

                    //On déchiffre la liste de mots de passe
                    string encryptedPassword = EncryptionManager.Decrypt(passwordList[1]);

                    //On déserialise le json de la liste de mot de passe
                    PasswordManager.PasswordList = JsonSerializer.Deserialize<List<Entry>>(encryptedPassword);
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
}
