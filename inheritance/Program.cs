namespace inheritance
{
    public class Asset
    {
        public string Name;
    }
    public class Stock : Asset // inherits from Asset
    {
        public long SharesOwned;
    }
    public class House : Asset // inherits from Asset
    {
        public decimal Mortgage;
    }

    public class Baseclass
    {
        public int X;
        public Baseclass() { }
        public Baseclass(int x) { this.X = x; }
    }
    public class Subclass : Baseclass
    {
        public Subclass(int x) : base(x) { }
    }

    // Implicit calling of the parameterless base-class constructor
    public class BaseClass1
    {
        public int X;
        public BaseClass1() { X = 1; }
    }
    public class Subclass1 : BaseClass1
    {
        public Subclass1() { Console.WriteLine(X); } // 1
    }

    internal class Program
    {
        public static void Display(Asset asset) // Polymorphism
        {
            System.Console.WriteLine(asset.Name);
        }

        static void Main(string[] args)
        {
            Stock msft = new Stock
            {
                Name = "MSFT",
                SharesOwned = 1000
            };
            Console.WriteLine(msft.Name); // MSFT
            Console.WriteLine(msft.SharesOwned); // 1000

            House mansion = new House
            {
                Name = "Mansion",
                Mortgage = 250000
            };
            Console.WriteLine(mansion.Name); // Mansion
            Console.WriteLine(mansion.Mortgage); // 250000


            // Polymorphism
            Display(msft);
            Display(mansion);

            Asset a = msft; // Upcast
            Stock s = (Stock)a; // Downcast
            Console.WriteLine(s.SharesOwned); // <No error>
            Console.WriteLine(s == a); // True
            Console.WriteLine(s == msft); // True


            // The as operator performs a downcast that evaluates to null
            Asset a1 = new Asset();
            Stock s1 = a1 as Stock; // s is null; no exception thrown
            if (s1 != null)
            {
                Console.WriteLine(s.SharesOwned);
            }
            else
            {
                Console.WriteLine("Doomed");
            }

            // The is operator tests whether a reference conversion would succeed; 
            if (s is Stock)
            {
                Console.WriteLine(((Stock)a).SharesOwned);
            }

            Subclass sc = new Subclass(123);
            Subclass1 sc1 = new Subclass1();
            Console.WriteLine(sc.X);
        }
    }
}