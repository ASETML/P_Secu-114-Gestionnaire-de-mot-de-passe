using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace P_Secu_114_WinForms
{
    /// <summary>
    /// An entry (password + username + url)
    /// </summary>
    public class Entry
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string Url { get; set; }

        public Entry(string password, string username, string url)
        {
            Password = password;
            Username = username;
            Url = url;
        }
    }
}
