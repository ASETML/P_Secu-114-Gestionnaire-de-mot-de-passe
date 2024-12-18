﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114_WinForms
{
    /// <summary>
    /// Create, delete, show entrys
    /// </summary>
    public static class PasswordManager
    {
        public static List<Entry> PasswordList { get; set; } = new List<Entry>();

        public static void AddEntry(string title, string password, string username, string url)
        {
            PasswordList.Add(new Entry(EncryptionManager.Encrypt(title), EncryptionManager.Encrypt(password), EncryptionManager.Encrypt(username), EncryptionManager.Encrypt(url)));
            SaveFile.SaveEntries();
        }

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
            SaveFile.SaveEntries();
        }

        public static void RemoveEntry(Entry entry)
        {
            PasswordList.Remove(entry);
            SaveFile.SaveEntries();
        }
    }
}
