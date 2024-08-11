namespace Lambda
{

    internal class Program
    {
        static void Foo<T>(T x) { }
        static void Bar<T>(Action<T> a) { }

        // Captured variables have their lifetimes extended to that of the delegate
        static Func<int> Natural()
        {
            int seed = 0;
            return () => seed++; // Returns a closure
        }
        static Func<int> Natural(int num)
        {
            //instantiate seed
            return () => { int seed = 0; return seed++; };
        }

        static void Main(string[] args)
        {
            // used most commonly with the Func and Action delegates

            // param, return 
            Func<int, int> sqr = x => x * x;
            int ret1 = sqr(2);
            Console.WriteLine(ret1);

            Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
            int total = totalLength("hello", "world"); // total is 10;

            Console.WriteLine(total);

            Bar<int>(x => Foo(x));

            int factor = 2;
            Func<int, int> multiplier = n => n * factor; // Capturing Outer Variables
            Console.WriteLine(multiplier(3));

            Func<int> natural = Natural();
            Console.WriteLine(natural()); // 0
            Console.WriteLine(natural()); // 1

            Func<int> natural1 = Natural(1);
            Console.WriteLine(natural1()); // 0
            Console.WriteLine(natural1()); // 0
        }
    }
}