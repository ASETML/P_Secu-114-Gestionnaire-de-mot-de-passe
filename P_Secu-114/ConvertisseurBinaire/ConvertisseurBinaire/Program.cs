namespace ConvertisseurBinaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> binary = Convert(Console.ReadLine());
            string str = "";

            foreach (int item in binary)
            {
                str += item.ToString();
            }
            Console.WriteLine(str);
            str = "";
            foreach (int item in InvertString(binary))
            {
                str += item.ToString();
            }
            Console.WriteLine(str);
        }

        static void ConvertBinary(string toConvert)
        {
            while (toConvert.Length > 0)
            {

            }
        }

        static List<int> Convert(string toConvert)
        {
            List<int> binary = new List<int>();
            int intToConvert = 0;
            string str = "";

            try
            {
                intToConvert = int.Parse(toConvert);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            while (intToConvert > 0)
            {
                binary.Add(intToConvert % 2);
                intToConvert /= 2;
            }

            return binary;
        }
        
        static List<int> InvertString(List<int> stringToInvert)
        {
            stringToInvert.Reverse();

            return stringToInvert;
        }
    }
}