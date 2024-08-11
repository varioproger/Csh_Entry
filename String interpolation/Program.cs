namespace String_interpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 4;
            Console.Write($"A square has {x} sides");

            string s = $"255 in hex is {byte.MaxValue:X2}"; // X2 = 2-digit Hexadecimal
                                                            // Evaluates to "255 in hex is FF"
            Console.WriteLine(s);

            int x1 = 2;
            string s1 = $@"this spans {x1} lines";
            Console.WriteLine(s1);
        }
    }
}