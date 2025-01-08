using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114_WinForms
{
    /// <summary>
    /// Chiffre et déchiffre avec Vigenère
    /// </summary>
    public static class EncryptionManager
    {
        /// <summary>
        /// Chiffre un texte
        /// </summary>
        /// <param name="text">Le texte à chiffrer</param>
        /// <returns>Un texte chiffré</returns>
        public static string Encrypt(string text)
        {
            string encryptedText = ""; //Le texte chiffré
            int keyIndex = 0; //L'index de la clé

            //Pour chaque charactère du texte
            foreach (char c in text)
            {
                //Si l'index de la clé est plus grand que la longueur de la clé, on revient au début de la clé
                if (keyIndex >= MasterPassword.Key.Length)
                {
                    keyIndex = 0;
                }

                int characterValue = (int)c; //Le code du caractère à chiffrer
                characterValue += (int)MasterPassword.Key[keyIndex]; //On ajoute le code du caractère de la clé au code du caratère à chiffrer
                encryptedText += (char)characterValue; //On ajoute le caractère chiffré au texte chiffré

                keyIndex++; //On incremente l'index de la clé
            }
            return encryptedText; //On retourne le texte chiffré
        }

        /// <summary>
        /// Déchiffre un text
        /// </summary>
        /// <param name="text">Le texte à déchiffrer</param>
        /// <returns>Un texte déchiffré</returns>
        public static string Decrypt(string text)
        {
            string decryptedText = ""; //Le texte déchiffré
            int keyIndex = 0; //L'index de la clé

            //Pour chaque charactère du texte
            foreach (char c in text)
            {
                //Si l'index de la clé est plus grand que la longueur de la clé, on revient au début de la clé
                if (keyIndex >= MasterPassword.Key.Length)
                {
                    keyIndex = 0;
                }

                int characterValue = (int)c; //Le code du caractère à déchiffrer
                characterValue -= (int)MasterPassword.Key[keyIndex]; //On soustrait le code du caractère de la clé au code du caratère à déchiffrer

                decryptedText += (char)characterValue; //On ajoute le caractère déchiffré au texte déchiffré

                keyIndex++; //On incremente l'index de la clé

            }
            return decryptedText; //On retourne le texte déchiffré
        }
    }
}
