using System.Runtime.InteropServices;

namespace Box_Unbox
{
    // all the members of object

    //public class Object
    //{
    //    public Object();
    //    public extern Type GetType();
    //    public virtual bool Equals(object obj);
    //    public static bool Equals(object objA, object objB);
    //    public static bool ReferenceEquals(object objA, object objB);
    //    public virtual int GetHashCode();
    //    public virtual string ToString();
    //    protected virtual void Finalize();
    //    protected extern object MemberwiseClone();
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 9;
            object obj = x; // Box the int
            int y = (int)obj; // Unbox the int

            obj = 9; // 9 is inferred to be of type int
            long x1 = (long)obj; // InvalidCastException
            // nhandled exception. System.InvalidCastException


            obj = 3.5; // 3.5 is inferred to be of type double
            x = (int)(double)obj; // x is now 3


            object[] a1 = new string[3]; // Legal
           // object[] a2 = new int[3]; // Error

            int i = 3;
            object boxed = i;
            i = 5;
            Console.WriteLine(boxed); // 3
        }
    }
}