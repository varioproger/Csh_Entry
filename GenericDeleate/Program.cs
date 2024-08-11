namespace GenericDeleate
{
    public delegate T Transformer<T>(T arg);

    //  the return value as covariant (out).
    delegate TResult Func<out TResult>();
    // Func<string> x = ...;
    // Func<object> y = x;


    //  parameters as contravariant (in).
    delegate void Action<in T>(T arg);
    // Action<object> x = ...;
    // Action<string> y = x;
    
    public class Util
    {
        public static void Transform<T>(T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3 };
            Util.Transform(values, Square); // Hook in Square
            foreach (int i in values)
                Console.Write(i + " "); // 1 4 9
        }
        static int Square(int x) => x * x;
    }
}