namespace P_Secu_114
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu();

            MasterPassword.Key = Console.ReadLine();
            Console.WriteLine(MasterPassword.Key);
            File.WriteAllText("pwd.txt", EncryptionManager.Encrypt(Console.ReadLine()));
            Console.WriteLine(EncryptionManager.Decrypt(File.ReadAllText("pwd.txt")));
           }
    }
}