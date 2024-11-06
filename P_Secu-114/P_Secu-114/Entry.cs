using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114
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
