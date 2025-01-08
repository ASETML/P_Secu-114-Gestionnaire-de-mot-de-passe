using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114_WinForms
{
    /// <summary>
    /// Créer, ajouter, supprimmer des entrées
    /// </summary>
    public static class PasswordManager
    {
        public static List<Entry> PasswordList { get; set; } = new List<Entry>(); //La liste de mot de passe

        /// <summary>
        /// Ajoute une entrée
        /// </summary>
        /// <param name="title">Le titre de l'entrée</param>
        /// <param name="password">Le mot de passe de l'entrée</param>
        /// <param name="username">Le nom d'utilisateur de l'entrée</param>
        /// <param name="url">L'adresse du site de l'entrée</param>
        public static void AddEntry(string title, string password, string username, string url)
        {
            PasswordList.Add(new Entry(EncryptionManager.Encrypt(title), EncryptionManager.Encrypt(password), EncryptionManager.Encrypt(username), EncryptionManager.Encrypt(url)));
            SaveFile.SaveEntries(); //On sauvegarde les entrées
        }

        /// <summary>
        /// Modifie une entrée
        /// </summary>
        /// <param name="fieldToModify">Le champ à modifier : "title" | "password" | "username" | "url"</param>
        /// <param name="newValue">La nouvelle valeur du champ</param>
        /// <param name="entry">L'entrée à modifier</param>
        public static void UpdateEntry(string fieldToModify, string newValue, Entry entry)
        {
            switch (fieldToModify)
            {
                case "title":
                    entry.Title = EncryptionManager.Encrypt(newValue);
                    break;
                case "password":
                    entry.Password = EncryptionManager.Encrypt(newValue);
                    break;
                case "username":
                    entry.Username = EncryptionManager.Encrypt(newValue);
                    break;
                case "url":
                    entry.Url = EncryptionManager.Encrypt(newValue);
                    break;
            }
            SaveFile.SaveEntries(); //On sauvegarde les entrées
        }

        /// <summary>
        /// Supprime une entrée
        /// </summary>
        /// <param name="entry">l'entrée à supprimer</param>
        public static void RemoveEntry(Entry entry)
        {
            PasswordList.Remove(entry); //Supprime l'entrée de la liste
            SaveFile.SaveEntries(); //On sauvegarde les entrées
        }
    }
}
