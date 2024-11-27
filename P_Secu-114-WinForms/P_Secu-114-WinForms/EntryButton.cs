using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114_WinForms
{
    public class EntryButton : Button
    {
        public EntryButton(Entry entry) : base()
        {
            Text = EncryptionManager.Decrypt(entry.Title);
            Tag = entry;
            Click += new EventHandler(this.button_Click);
        }

        public void button_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            Form formToClose = parentForm.ActiveMdiChild;

            if (formToClose != null)
            {
                formToClose.Close();
            }

            Form form = new EntryForm((Entry)this.Tag);

            form.MdiParent = parentForm;
            form.Show();
            form.Left = 85;
            form.Top = 15;
            form.Name = this.Tag.ToString();
        }
    }
}
