using System.Drawing;

namespace class_array
{
    public struct stPoint { public int X, Y; } // value type

    public class CPoint { public int X, Y; }// reference type


    internal class Program
    {
        static void Main(string[] args)
        {
            stPoint[] st = new stPoint[1000];
            Console.WriteLine(st[500].X);

            // 클래스는 배열만 생성하는게 아니라 안에 요서까지 같이 생성해줘야 에러가 안난다.
            CPoint[] c = new CPoint[1000];
            // 아래 코드가 없으면 에러 뜸
            /*
            Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
            at class_array.Program.Main(String[] args) in E:\c#\Csh_Entry\class_array\Program.cs:line 16 
            */
            for (int i = 0; i < c.Length; i++) // Iterate i from 0 to 999
            {
                c[i] = new CPoint(); // Set array element i with new point
            }
            Console.WriteLine(c[500].X);
        }
    }
}