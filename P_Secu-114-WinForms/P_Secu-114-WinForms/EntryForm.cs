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
    /// <summary>
    /// Le menu d'affichage des entrées
    /// </summary>
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

            textBox4.Text = _userName;
            textBox3.Text = _password;

            textBox2.Text = _url;
            textBox1.Text = _title;

            textBox1.Width = 450;
            textBox2.Width = 450;
            textBox3.Width = 450;
            textBox4.Width = 450;
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

            Navigation form = new Navigation((MainMenu)this.ParentForm);
            MainMenu parentForm = (MainMenu)this.ParentForm;
            parentForm.NavForm = form;

            foreach (Control c in parentForm.Controls)
            {
                if (c.Text == "Titre" || c.Text == "URL" || c.Text == "Nom d'utilisateur" || c.Text == "Mot de passe" || c.Text == "Ajouter un mot de passe")
                {
                    c.Show();
                }
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(PictureBox))
                {
                    c.Show();
                }
            }

            form.Show();
            form.ShowEntryList();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation form = new Navigation((MainMenu)this.ParentForm);
            MainMenu parentForm = (MainMenu)this.ParentForm;
            parentForm.NavForm = form;

            foreach (Control c in parentForm.Controls)
            {
                if (c.Text == "Titre" || c.Text == "URL" || c.Text == "Nom d'utilisateur" || c.Text == "Mot de passe" || c.Text == "Ajouter un mot de passe")
                {
                    c.Show();
                }
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(PictureBox))
                {
                    c.Show();
                }
            }

            form.Show();
            form.ShowEntryList();
            this.Close();
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
            pictureBox4.Image = Properties.Resources.eye_regular;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            pictureBox4.Image = Properties.Resources.eye_solid;
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
            pictureBox5.Image = Properties.Resources.eye_regular;
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            pictureBox5.Image = Properties.Resources.eye_solid;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.copy_regular;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.copy_solid;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.copy_regular;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.copy_solid;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.copy_regular;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.copy_solid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _entry.Title = EncryptionManager.Encrypt(textBox1.Text);
            SaveFile.SaveEntries();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _entry.Url = EncryptionManager.Encrypt(textBox2.Text);
            SaveFile.SaveEntries();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _entry.Username = EncryptionManager.Encrypt(textBox4.Text);
            SaveFile.SaveEntries();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _entry.Password = EncryptionManager.Encrypt(textBox3.Text);
            SaveFile.SaveEntries();
        }
    }
}
