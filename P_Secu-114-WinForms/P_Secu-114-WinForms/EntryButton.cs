using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114_WinForms
{
    /// <summary>
    /// Un bouton qui ouvre un entryForm
    /// </summary>
    public class EntryButton : Button
    {
        public EntryButton(Entry entry) : base()
        {
            Text = EncryptionManager.Decrypt(entry.Title); //Affiche le titre de l'entrée sur le bouton
            Tag = entry; //On y attache l'entrée
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
            form.Left = 5;
            form.Top = 15;
            form.Name = this.Tag.ToString();

            //Cache la zone de sélection de mot de passe
            foreach (Control c in parentParentForm.Controls)
            {
                //Cache les titres
                if (c.Text == "Titre" || c.Text == "URL" || c.Text == "Nom d'utilisateur" || c.Text == "Mot de passe" || c.Text == "Ajouter un mot de passe")
                {
                    c.Hide();
                }
                //Cache les zones de saisies
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(PictureBox))
                {
                    c.Hide();
                }
            }
        }
    }
}
