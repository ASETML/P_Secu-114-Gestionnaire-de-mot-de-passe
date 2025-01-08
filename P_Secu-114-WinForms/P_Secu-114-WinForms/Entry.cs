using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace P_Secu_114_WinForms
{
    /// <summary>
    /// Une entrée (titre + mdp + nom d'utilisateur + url)
    /// </summary>
    public class Entry
    {
        public string Title { get; set; } //Le titre de l'entrée
        public string Password { get; set; } //Le mot de passe
        public string Username { get; set; } //Le nom d'utilisateur
        public string Url { get; set; } //L'adresse du site

        public Entry(string title, string password, string username, string url)
        {
            Title = title;
            Password = password;
            Username = username;
            Url = url;
        }
    }
}
