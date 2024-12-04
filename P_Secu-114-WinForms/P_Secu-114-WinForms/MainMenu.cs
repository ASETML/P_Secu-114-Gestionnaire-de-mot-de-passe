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

        public MainMenu()
        {
            this.IsMdiContainer = true;
            InitializeComponent();

            System.Windows.Forms.Timer reloadTimer = new System.Windows.Forms.Timer();
            reloadTimer.Interval = 500;
            reloadTimer.Tick += ReloadTimer_Tick;
            reloadTimer.Start();
        }

        private void ReloadTimer_Tick(object? sender, EventArgs e)
        {
            ShowEntryList();

            int count = PasswordManager.PasswordList.Count();

            if (count > 0)
            {
                reloadTimer.Interval = count * 150;
            }
        }

        private void test()
        {
            PasswordManager.AddEntry("test1", "pwd", "user", "localhost");
            PasswordManager.AddEntry("test2", "dfgh", "fgh", "hdf");
            PasswordManager.AddEntry("test3", "dhgf", "usdfgher", "locfdhgalhost");
            PasswordManager.AddEntry("test4", "fdhfdh", "dffghh", "locadfghdfhlhost");
            PasswordManager.AddEntry("test5", "fdgh", "dfh", "localhodfghdfhst");
            PasswordManager.AddEntry("test6", "pdfghwd", "dfggh", "gfhfh");
            ShowEntryList();
        }

        private void ShowEntryList()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(EntryButton))
                {
                    this.Controls.Remove(control);
                }
            }

            int i = 15;
            foreach (Entry entry in PasswordManager.PasswordList)
            {
                EntryButton btn = new EntryButton(entry);
                this.Controls.Add(btn);
                btn.Top = i;
                i += 25;
            }

            pictureBox1.Hide();
            label1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordManager.AddEntry(textBox1.Text, textBox4.Text, textBox3.Text, textBox2.Text);
            ShowEntryList();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            test();
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
            ShowEntryList();
            textBox5.Hide();
            button2.Hide();
            pictureBox3.Hide();
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