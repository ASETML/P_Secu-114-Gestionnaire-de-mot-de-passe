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
                Console.WriteLine(characterValue + "c: ");
                characterValue += (int)MasterPassword.Key[i];

                Console.WriteLine(characterValue + "k: ");

                encryptedText += (char)characterValue;

                i++;
                
            }

            i = 0;
            foreach (char c2 in encryptedText)
            {
                if (i >= MasterPassword.Key.Length)
                {
                    i = 0;
                }
                int characterValue = (int)c2;
                Console.WriteLine(characterValue + "c: ");
                characterValue -= (int)MasterPassword.Key[i];

                Console.WriteLine(characterValue + "i: ");

                //encryptedText += (char)characterValue;

                i++;
                
            }

            Console.WriteLine(encryptedText);

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
                Console.WriteLine(characterValue + "c: ");
                characterValue -= (int)MasterPassword.Key[i];

                Console.WriteLine(characterValue + "i: ");

                decryptedText += (char)characterValue;

                i++;
                
            }

            Console.WriteLine(decryptedText);
            return decryptedText;
        }
    }
}
