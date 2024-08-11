namespace Object
{
    internal class Program
    {
        public class Bunny
        {
            public string Name;
            public bool LikesCarrots;
            public bool LikesHumans;
            public Bunny() { }
            public Bunny(string name,
                         bool likesCarrots = false,
                         bool likesHumans = false)
            {
                Name = name;
                LikesCarrots = likesCarrots;
                LikesHumans = likesHumans;
            }

            public Bunny(string n) { Name = n; }
        }

        public class Stock
        {
            int currentPrice, sharesOwned = 10; // The private "backing" field

            public decimal CurrentPrice2 { get; set; } = 123;

            public int CurrentPrice // The public property
            {
                get { return currentPrice; }
                set { currentPrice = value; }
            }
            public int Worth => currentPrice * sharesOwned; // Expression-bodied properties : get only
        }

        public class Foo
        {
            private decimal x;
            public decimal X
            {
                // different access levels
                get { return x; }
                private set { x = Math.Round(value, 2); }
            }
        }

        // Static constructors and field initialization order
        class Foo1
        {
            public static Foo1 Instance = new Foo1();
            public static int X = 3;
            Foo1() { Console.WriteLine(X); } // 0
        }

        class Foo2
        {
            public static int X = 3;
            public static Foo2 Instance = new Foo2();
            Foo2() { Console.WriteLine(X); } // 0
        }

        class Foo3
        {
            public static int X = 13;
            Foo3() { Console.WriteLine(X); } // 0
        }
        static void Main(string[] args)
        {
            Bunny b1 = new Bunny { Name = "Bo1", LikesCarrots = true, LikesHumans = false };
            Bunny b2 = new Bunny("Bo2") { LikesCarrots = false, LikesHumans = false };
            Bunny b3 = new Bunny(name: "Bo3", likesCarrots: true);

            Console.WriteLine(b1.Name);
            Console.WriteLine(b1.LikesCarrots);
            Console.WriteLine(b1.LikesHumans);

            Console.WriteLine(b2.Name);
            Console.WriteLine(b2.LikesCarrots);
            Console.WriteLine(b2.LikesHumans);

            Console.WriteLine(b3.Name);
            Console.WriteLine(b3.LikesCarrots);
            Console.WriteLine(b3.LikesHumans);


            Stock stock = new Stock();
            stock.CurrentPrice = 10;
            var temp = stock.CurrentPrice;
            Console.WriteLine(stock.CurrentPrice);
            Console.WriteLine(temp);
            temp = stock.Worth;
            Console.WriteLine(temp);
            Console.WriteLine(stock.CurrentPrice2);


            Console.WriteLine(Foo1.X);
            Console.WriteLine(Foo2.X);
            Console.WriteLine(Foo3.X);
        }
    }
}