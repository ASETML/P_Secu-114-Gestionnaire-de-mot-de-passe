namespace P_Secu_114
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            /*Console.WriteLine("Enter MasterPassword");
            MasterPassword.Key = Console.ReadLine();
            Console.WriteLine(EncryptionManager.Decrypt(File.ReadAllText("pwd.txt")));

            File.WriteAllText("pwd.txt", EncryptionManager.Encrypt(Console.ReadLine()));
            Console.WriteLine(EncryptionManager.Decrypt(File.ReadAllText("pwd.txt")));
            */

            do
            {
                Console.WriteLine("**************************************************************************************");
                Console.WriteLine("1. Consulter un mot de passe");
                Console.WriteLine("2. Ajouter un mot de passe");
                Console.WriteLine("3. Supprimer un mot de passe");
                Console.WriteLine("4. Quitter le programme");
                Console.WriteLine("**************************************************************************************");
                bool b = true;
                Console.WriteLine("a");
            } while (true);
        }
    }
}