using System;
using System.Collections.Generic;


namespace Generic
{
    public class Stack<T>
    {
        int position;
        T[] data = new T[100];
        public void Push(T obj) => data[position++] = obj;
        public T Pop() => data[--position];
    }

    internal class Program
    {
        // Generic Methods
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        // Generic Constraints
        /*
            where T : base-class // Base-class constraint
            where T : interface // Interface constraint
            where T : class // Reference-type constraint
            where T : struct // Value-type constraint (excludes Nullable types)
            where T : new() // Parameterless constructor constraint
            where U : T // Naked type constraint
         */
        static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }


        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            int x = stack.Pop(); // x is 10
            int y = stack.Pop(); // y is 5

            Swap(ref x, ref y);
            Console.WriteLine("{0},{1}",x,y);

            var z = Max(5, 10); // 10
            string last = Max("ant", "zoo"); // zoo
            Console.WriteLine("{0},{1}",z,last);    
        }
    }
}