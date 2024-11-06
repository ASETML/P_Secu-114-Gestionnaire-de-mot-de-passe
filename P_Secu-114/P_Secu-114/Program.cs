namespace P_Secu_114
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MasterPassword.Key = Console.ReadLine();
            Console.WriteLine(MasterPassword.Key);
            File.WriteAllText("pwd.txt", EncryptionManager.Encrypt("etml"));
            EncryptionManager.Decrypt(EncryptionManager.Encrypt("aabbcc ■☺"));
            Console.WriteLine(EncryptionManager.Decrypt(File.ReadAllText("pwd.txt")));
        }
    }
}