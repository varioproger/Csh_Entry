namespace Delegates
{
    //  delegate is an object that knows how to call a method
    internal class Program
    {
        delegate int Transformer(int x);

        class Util
        {
            public static void Transform(int[] values, Transformer t) // Plug-in Methods
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t(values[i]);
            }
        }

        static void Main(string[] args)
        {
            Transformer t = Square;
            Transformer t2 = Square2;
            Transformer t3 = Square3;

            // shorthand for:
            // Transformer t = new Transformer(Square);

            int result = t(3); // Invoke delegate
            Console.WriteLine(result); // 9

            int result2 = t2(3); // Invoke delegate
            Console.WriteLine(result2); // 9

            int result3 = t3(3); // Invoke delegate
            Console.WriteLine(result3); // 9

            int[] values = { 1, 2, 3 };
            Util.Transform(values, Square); // Hook in the Square method

            foreach (int i in values)
                Console.Write(i + " "); // 1 4 9
        }
        static int Square(int x) { return x * x; }
        static int Square2(int x) { return x * x; }
        static int Square3(int x) { return x * x; }

    }
}