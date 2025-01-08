using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace P_Secu_114_WinForms
{
    /// <summary>
    /// Le menu principal
    /// </summary>
    public partial class MainMenu : Form
    {
        System.Windows.Forms.Timer reloadTimer = new System.Windows.Forms.Timer();
        public Navigation NavForm { get; set; }

        public MainMenu()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
            NavForm = new Navigation(this);
            NavForm.ShowEntryList();

            label1.Hide();
            HideAddPassword();

            this.Controls.Remove(pictureBox1);
            pictureBox1.Hide();
        }

        private void ShowAddPassword()
        {
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();

            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();

            pictureBox2.Show();
            button1.Show();
        }

        private void HideAddPassword()
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();

            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();

            pictureBox2.Hide();
            button1.Hide();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "button1":
                    if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
                    {
                        PasswordManager.AddEntry(textBox1.Text, textBox4.Text, textBox3.Text, textBox2.Text);
                        NavForm.ShowEntryList();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    break;
                case "button2":
                    SaveFile.ReadEntries(textBox5.Text);
                    NavForm.ShowEntryList();
                    textBox5.Hide();
                    button2.Hide();
                    pictureBox3.Hide();
                    this.Controls.Remove(textBox5);
                    this.Controls.Remove(button2);
                    this.Controls.Remove(pictureBox3);

                    ShowAddPassword();
                    break;
                case "button4":
                    Application.Exit();
                    break;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            switch (pictureBox.Name)
            {
                case "pictureBox2":
                    textBox4.UseSystemPasswordChar = false;
                    pictureBox2.Image = Properties.Resources.eye_regular;
                    break;
                case "pictureBox3":
                    textBox5.UseSystemPasswordChar = false;
                    pictureBox3.Image = Properties.Resources.eye_regular;
                    break;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            switch (pictureBox.Name)
            {
                case "pictureBox2":
                    textBox4.UseSystemPasswordChar = true;
                    pictureBox2.Image = Properties.Resources.eye_solid;
                    break;
                case "pictureBox3":
                    textBox5.UseSystemPasswordChar = true;
                    pictureBox3.Image = Properties.Resources.eye_solid;
                    break;
            }
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            textBox5.Focus();
        }
    }
}