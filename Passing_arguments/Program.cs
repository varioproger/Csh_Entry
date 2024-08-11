using System.Text;

namespace Passing_arguments
{
    internal class Program
    {
        static void VALUE(int p)
        {
            p = p + 1; // Increment p by 1
        }
        static void Ref_Type_Value(StringBuilder fooSB) // reference-type argument by value copies the reference, but not the object.
        {
            // Sees the same StringBuilder object that Main instantiated, but has an independent reference to it.
            // In short,  sb and fooSB are separate variables that reference the same StringBuilder object
            fooSB.Append("test");
            fooSB = null;
        }
        static void REF(ref int p)
        {
            p = p + 1; // Increment p by 1
        }
        static void Split(string name, out string firstNames, out string lastName)
        {
            int i = name.LastIndexOf(' ');
            firstNames = name.Substring(0, i);
            lastName = name.Substring(i + 1);
        }

        /*
            The params parameter modifier may be specified on the last parameter of a method
            so that the method accepts any number of arguments of a particular type. 
            The parameter type must be declared as an array. 
         */
        static int Sum(params int[] ints)
        {
            int sum = 0;
            for (int i = 0; i < ints.Length; i++)
                sum += ints[i]; // Increase sum by ints[i]
            return sum;
        }

        static void Foo(int x = 0, int y = 0)
        { 
            Console.WriteLine(x + ", " + y);
        }
        static void Main(string[] args)
        {
            int x = 8;
            VALUE(x); // Make a copy of x
            Console.WriteLine(x); // x will still be 8

            REF(ref x); 
            Console.WriteLine(x); // 9

            string a, b;
            /*
                • Need not be assigned before going into the function
                • Must be assigned before it comes out of the function
             */

            Split("Stevie Ray Vaughan", out a, out b);
            Console.WriteLine(a); // Stevie Ray
            Console.WriteLine(b); // Vaughan

            StringBuilder sb = new StringBuilder();
            Ref_Type_Value(sb);
            Console.WriteLine(sb.ToString()); // test


            int total = Sum(1, 2, 3, 4);
            Console.WriteLine(total); // 10

            Foo();
            Foo(1);
            Foo(x: 1, y: 2); // 1, 2
            // Named arguments

        }
    }
}