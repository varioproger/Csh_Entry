namespace array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = new char[5]; // Declare an array of 5 characters
            vowels[0] = 'a';
            vowels[1] = 'e';
            vowels[2] = 'i';
            vowels[3] = 'o';
            vowels[4] = 'u';
            Console.WriteLine(vowels[1]); // 

            for (int i = 0; i < vowels.Length; i++)
            {
               Console.Write(vowels[i]); // aeiou
            }
            Console.WriteLine();
            char[] vowels2 = { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < vowels2.Length; i++)
            {
                Console.Write(vowels2[i]); // aeiou
            }
        }
    }
}