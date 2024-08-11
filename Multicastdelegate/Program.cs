namespace Multicastdelegate
{
    // All delegate instances have multicast capability.
    public delegate void ArithmaticOp(int Num);
    public class Util
    {
        public static void Calculator(ArithmaticOp p)
        {
            p(2); // Invoke delegate
        }
    }
    public delegate void ProgressReporter(int percentComplete);


    internal class Program
    {
        static void Main(string[] args)
        {
            ArithmaticOp ao = Add;
            ao += Subtract;
            ao += Multiple;
            ao += Divide;
            Util.Calculator(ao);

            /*
            When an instance method is assigned to a delegate object, 
            the latter must maintain a reference not only to the method, but also to the instance to which the method belongs. 
            The System.Delegate class’s Target property represents this instance 
            (and will be null for a delegate referencing a static method)
            */
            X x = new X();
            ProgressReporter p = x.InstanceProgress;
            p(99); // 99
            Console.WriteLine(p.Target == x); // True
            Console.WriteLine(p.Method); // Void InstanceProgress(Int32)


        }
        static void Add(int Num) => Console.WriteLine(Num+ Num);
        static void Subtract(int Num) => Console.WriteLine(Num - Num);
        static void Multiple(int Num) => Console.WriteLine(Num * Num);
        static void Divide(int Num) => Console.WriteLine(Num/ Num);

    }
    class X
    {
        public void InstanceProgress(int percentComplete)
        => Console.WriteLine(percentComplete);
    }
}