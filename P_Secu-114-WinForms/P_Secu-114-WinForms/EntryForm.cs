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

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender; 
            switch (pictureBox.Name)
            {
                case "pictureBox1":
                    pictureBox1.Image = Properties.Resources.copy_regular;
                    break;
                case "pictureBox2":
                    pictureBox2.Image = Properties.Resources.copy_regular;
                    break;
                case "pictureBox3":
                    pictureBox3.Image = Properties.Resources.copy_regular;
                    break;
                case "pictureBox4":
                    textBox3.UseSystemPasswordChar = false;
                    pictureBox4.Image = Properties.Resources.eye_regular;
                    break;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            switch (pictureBox.Name)
            {
                case "pictureBox1":
                    pictureBox1.Image = Properties.Resources.copy_solid;
                    break;
                case "pictureBox2":
                    pictureBox2.Image = Properties.Resources.copy_solid;
                    break;
                case "pictureBox3":
                    pictureBox3.Image = Properties.Resources.copy_solid;
                    break;
                case "pictureBox4":
                    textBox3.UseSystemPasswordChar = true;
                    pictureBox4.Image = Properties.Resources.eye_solid;
                    break;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            switch (pictureBox.Name)
            {
                case "pictureBox1":
                    Clipboard.SetText(_url);
                    break;
                case "pictureBox2":
                    Clipboard.SetText(_userName);
                    break;
                case "pictureBox3":
                    Clipboard.SetText(_password);
                    break;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "button1":
                    PasswordManager.RemoveEntry(_entry);
                    break;
            }

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

        private void updateButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "button3":
                    _entry.Title = EncryptionManager.Encrypt(textBox1.Text);
                    _title = textBox1.Text;
                    break;
                case "button4":
                    _entry.Url = EncryptionManager.Encrypt(textBox2.Text);
                    _url = textBox2.Text;
                    break;
                case "button5":
                    _entry.Username = EncryptionManager.Encrypt(textBox4.Text);
                    _userName = textBox4.Text;
                    break;
                case "button6":
                    _entry.Password = EncryptionManager.Encrypt(textBox3.Text);
                    _password = textBox3.Text;
                    break;
            }
            SaveFile.SaveEntries();
        }
    }
}
