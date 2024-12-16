using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Secu_114_WinForms
{
    public partial class Navigation : Form
    {
        private Form _parentForm;
        public Navigation(MainMenu form)
        {
            InitializeComponent();
            _parentForm = form;
            this.MdiParent = _parentForm;
            this.Show();
            this.Top = 0;
            this.Left = 0;
        }

        public void ShowEntryList()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(EntryButton))
                {
                    this.Controls.Remove(control);
                }
            }

            int i = 15;
            int y = 5;
            foreach (Entry entry in PasswordManager.PasswordList)
            {
                if (i > this.Height)
                {
                    y += 150;
                    i = 15;
                }
                EntryButton btn = new EntryButton(entry);
                this.Controls.Add(btn);
                btn.Top = i;
                btn.Left = y;
                i += 25;
            }
        }
    }
}
