public struct stPoint { public int X, Y; }
public class CPoint { public int X, Y; }

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("구조체");
        stPoint p1 = new stPoint();
        p1.X = 7;
        stPoint p2 = p1; // Assignment causes No copy
        Console.WriteLine(p1.X); // 7
        Console.WriteLine(p2.X); // 7
        p1.X = 9; // Change p1.X
        Console.WriteLine(p1.X); // 9
        Console.WriteLine(p2.X); // 7

        Console.WriteLine();
        Console.WriteLine("클래스");
        CPoint p3 = new CPoint();
        p3.X = 7;
        CPoint p4 = p3; // Assignment causes copy
        Console.WriteLine(p3.X); // 7
        Console.WriteLine(p4.X); // 7
        p3.X = 9; // Change p1.X
        Console.WriteLine(p3.X); // 9
        Console.WriteLine(p4.X); // 9
    }
}
