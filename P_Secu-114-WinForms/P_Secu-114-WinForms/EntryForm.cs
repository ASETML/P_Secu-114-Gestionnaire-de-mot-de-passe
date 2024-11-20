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
        private Entry _entry;
        public EntryForm(Entry entry)
        {
            InitializeComponent();
            _entry = entry;
            WriteEntry();
        }

        public void WriteEntry()
        {
            label1.Text = EncryptionManager.Decrypt(_entry.Url);
            label2.Text = EncryptionManager.Decrypt(_entry.Username);
            label3.Text = EncryptionManager.Decrypt(_entry.Password);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label3.Text);
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
