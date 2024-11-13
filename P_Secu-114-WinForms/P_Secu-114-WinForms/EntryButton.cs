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
            Text = EncryptionManager.Decrypt(entry.Url);
            Tag = entry;
            Click += new EventHandler(this.button_Click);
        }

        public void button_Click(object sender, EventArgs e)
        {
            new EntryForm((Entry)this.Tag).Show();
        }
    }
}
