namespace Contravariance
{
    delegate void StringAction(string s);
    delegate object ObjectRetriever();

    internal class Program
    {
        static void Main(string[] args)
        {
            //delegate can have more specific parameter types than its method target
            StringAction sa = new StringAction(ActOnObject);
            // A delegate merely calls a method on someone else’s behalf.
            // When the argument is then relayed to the target method, the argument gets implicitly upcast to an object.
            sa("hello");

            ObjectRetriever o = new ObjectRetriever(RetrieveString);
            object result = o();
            Console.WriteLine(result); // hello

        }
        static void ActOnObject(object o) => Console.WriteLine(o); // hell
        static string RetrieveString() => "hello";
    }
}