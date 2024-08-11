namespace TupleList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<uint, string>> users = new List<Tuple<uint, string>>();

            users.Add(Tuple.Create((uint)1, "Yes1"));
            users.Add(Tuple.Create((uint)2, "Yes2"));
            users.Add(Tuple.Create((uint)3, "Yes3"));
            users.Add(Tuple.Create((uint)4, "Yes4"));
            users.Add(Tuple.Create((uint)5, "Yes5"));

            for(int i =0;i<users.Count;i++) 
            {
                Console.WriteLine(users[i].Item1);
                Console.WriteLine(users[i].Item2);
            }
        }
    }
}