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
        Entry testentry = new Entry(EncryptionManager.Encrypt("pwd"), "user", "localhost");

        public MainMenu()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
            ShowEntryList();

            System.Windows.Forms.Timer reloadTimer = new System.Windows.Forms.Timer();
            reloadTimer.Interval = 2500;
            reloadTimer.Tick += ReloadTimer_Tick;
            reloadTimer.Start();

            SaveFile.ReadEntries("a");
        }

        private void ReloadTimer_Tick(object? sender, EventArgs e)
        {
            ShowEntryList();
        }

        private void test()
        {
            PasswordManager.AddEntry("pwd", "user", "localhost");
            PasswordManager.AddEntry("dfgh", "fgh", "hdf");
            PasswordManager.AddEntry("dhgf", "usdfgher", "locfdhgalhost");
            PasswordManager.AddEntry("fdhfdh", "dffghh", "locadfghdfhlhost");
            PasswordManager.AddEntry("fdgh", "dfh", "localhodfghdfhst");
            PasswordManager.AddEntry("pdfghwd", "dfggh", "gfhfh");
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

            if (pictureBox1.Visible)
            {
                pictureBox1.Hide();
            }

            if (label1.Visible)
            {
                label1.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordManager.AddEntry(textBox3.Text, textBox2.Text, textBox1.Text);
            ShowEntryList();
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
    }
}