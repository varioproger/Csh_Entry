namespace var
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = 5;
            var str = new string('a', num);
            Console.WriteLine(num + str);
        }
    }
}