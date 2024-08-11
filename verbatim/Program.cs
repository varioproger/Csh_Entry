namespace verbatim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a1 = "\\\\server\\fileshare\\helloworld.cs";
            string a2 = @"\\server\fileshare\helloworld.cs";
            string escaped = "First Line\r\nSecond Line";
            string verbatim = @"First Line
Second Line";

            string xml = @"<customer id=""123""></customer>";

            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine(escaped);
            Console.WriteLine(verbatim);
            Console.WriteLine(xml);
        }
    }
}