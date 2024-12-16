using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace P_Secu_114_WinForms
{
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
            pictureBox1.Hide();
            label1.Hide();

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

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                PasswordManager.AddEntry(textBox1.Text, textBox4.Text, textBox3.Text, textBox2.Text);
                NavForm.ShowEntryList();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(MdiClient))
                {
                    control.BackColor = Color.White;
                }
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
            pictureBox2.Image = Properties.Resources.eye_regular;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            pictureBox2.Image = Properties.Resources.eye_solid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFile.ReadEntries(textBox5.Text);
            NavForm.ShowEntryList();
            textBox5.Hide();
            button2.Hide();
            pictureBox3.Hide();

            ShowAddPassword();
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox5.UseSystemPasswordChar = false;
            pictureBox3.Image = Properties.Resources.eye_regular;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
            pictureBox3.Image = Properties.Resources.eye_solid;
        }
    }
}