using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using P_Secu_114_WinForms;

namespace P_Secu_114_WinForms
{
    public partial class EntryForm : Form
    {
        string _title;
        string _url;
        string _userName;
        string _password;

        private Entry _entry;
        public EntryForm(Entry entry)
        {
            InitializeComponent();
            _entry = entry;
            WriteEntry();
        }

        public void WriteEntry()
        {
            _title = EncryptionManager.Decrypt(_entry.Title);
            _url = EncryptionManager.Decrypt(_entry.Url);
            _userName = EncryptionManager.Decrypt(_entry.Username);
            _password = EncryptionManager.Decrypt(_entry.Password);

            label2.Text = Helpers.HidePassword(_userName.Length);
            label3.Text = Helpers.HidePassword(_password.Length);

            label7.Text = _title;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_url);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_userName);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordManager.RemoveEntry(_entry);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
