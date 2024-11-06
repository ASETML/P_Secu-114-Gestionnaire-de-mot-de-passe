using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Secu_114
{
    /// <summary>
    /// Encrypt password using Vigenère
    /// </summary>
    public static class EncryptionManager
    {
        /// <summary>
        /// Encrypt a text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            string encryptedText = "";
            int i = 0;

            foreach (char c in text)
            {
                if (i >= MasterPassword.Key.Length)
                {
                    i = 0;
                }
                int characterValue = (int)c;
                characterValue += (int)MasterPassword.Key[i];
                encryptedText += (char)characterValue;

                i++;

            }
            return encryptedText;
        }

        /// <summary>
        /// Decrypt a text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string text)
        {
            string decryptedText = "";
            int i = 0;
            foreach (char c in text)
            {
                if (i >= MasterPassword.Key.Length)
                {
                    i = 0;
                }
                int characterValue = (int)c;
                characterValue -= (int)MasterPassword.Key[i];

                decryptedText += (char)characterValue;

                i++;
                
            }
            return decryptedText;
        }
    }
}
