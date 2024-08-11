namespace EventHandlerNS
{
    public class Stock
    {
        string symbol;
        decimal price;
        public Stock(string symbol) { this.symbol = symbol; }

        public event EventHandler PriceChanged; // The compiler converts this to the following:
        /*
          // A private delegate field
               private EventHandler priceChanged;

          // A public pair of event accessor functions
              public event EventHandler PriceChanged
              {
                  add { priceChanged += value; }
                  remove { priceChanged -= value; }
              }
        This example is functionally identical to C#’s default accessor implementation
        */
        protected virtual void OnPriceChanged(EventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                price = value;
                OnPriceChanged(EventArgs.Empty);
            }
        }
    }

    public delegate void MyEventHandler(object sender, EventArgs e);

    public class Stock2
    {
        string symbol;
        decimal price;
        public Stock2(string symbol) { this.symbol = symbol; }

        // A private delegate field
        private MyEventHandler priceChanged;

        // A public pair of event accessor functions
        public event MyEventHandler PriceChanged2
        {
            add { priceChanged += value; }
            remove { priceChanged -= value; }
        }

        /*
         
        This example is functionally identical to C#’s default accessor implementation
        */
        protected void OnPriceChanged(EventArgs e)
        {
            if (priceChanged != null)
            {
                priceChanged(this,e);
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                price = value;
                OnPriceChanged(EventArgs.Empty);
            }
        }
    }
    //Like methods, events can be virtual, overridden, abstract, or sealed. Events can also be static:
    public class Foo
    {
        public static event EventHandler<EventArgs> StaticEvent;
        public virtual event EventHandler<EventArgs> VirtualEvent;
    }

    internal class Program
    {
        static void Main()
        {
            Stock stock = new Stock("THPW");
            stock.PriceChanged += new EventHandler(stock_PriceChanged1);
            stock.PriceChanged += new EventHandler(stock_PriceChanged2);
            stock.PriceChanged -= new EventHandler(stock_PriceChanged2);

            stock.Price = 27.10M;
            stock.Price = 31.59M;
            stock.Price = 35.59M;

            Stock2 stock2 = new Stock2("THPW");
            stock2.PriceChanged2 += new MyEventHandler(stock2_PriceChanged1);
            stock2.PriceChanged2 += new MyEventHandler(stock2_PriceChanged2);
            stock2.PriceChanged2 -= new MyEventHandler(stock2_PriceChanged2);

            stock2.Price = 27.10M;
            stock2.Price = 31.59M;
            stock2.Price = 35.59M;
        }
        static void stock_PriceChanged1(object sender, EventArgs e)
        {
            Stock stock = (Stock)sender;
           Console.WriteLine(stock.Price);
        }
        static void stock_PriceChanged2(object sender, EventArgs e)
        {
            Stock stock = (Stock)sender;
            Console.WriteLine(stock.Price);
        }
        static void stock2_PriceChanged1(object sender, EventArgs e)
        {
            Stock2 stock = (Stock2)sender;
            Console.WriteLine(stock.Price);
        }
        static void stock2_PriceChanged2(object sender, EventArgs e)
        {
            Stock2 stock = (Stock2)sender;
            Console.WriteLine(stock.Price);
        }
    }
}