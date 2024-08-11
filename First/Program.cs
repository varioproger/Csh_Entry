namespace First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FeetToInches(2));
        }
        static int FeetToInches(int feet) //c/c++ 와 다르게 위에 먼저 선언하지 않아도 된다.
        {
            int inches = feet * 12;
            return inches;
        }
    }
}