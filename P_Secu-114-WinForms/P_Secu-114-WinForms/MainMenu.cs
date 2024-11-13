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
            InitializeComponent();
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
            int i = 0;
            foreach (Entry entry in PasswordManager.PasswordList)
            {
                EntryButton btn = new EntryButton(entry);
                this.Controls.Add(btn);
                btn.Top = i;
                i += 25;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button_Click(object sender, EventArgs e)
        {
            new EntryForm((Entry)this.Tag).ShowDialog();
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
    }
}