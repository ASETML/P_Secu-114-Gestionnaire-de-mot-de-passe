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
            this.Width = 150;
        }

        public void button_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            Form parentParentForm = parentForm.ParentForm;

            Form formToClose = parentParentForm.ActiveMdiChild;

            if (formToClose != null)
            {
                formToClose.Close();
            }

            Form form = new EntryForm((Entry)this.Tag);

            form.MdiParent = parentParentForm;
            form.Show();
            form.Left = 15;
            form.Top = 15;
            form.Name = this.Tag.ToString();
        }
    }
}
