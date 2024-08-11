using System;

namespace Events
{
    /*
    There are three rules:
        • It must have a void return type.
        • It must accept two arguments: the first of type object, and the second a subclass of EventArgs.
          The first argument indicates the event broadcaster, and the
          second argument contains the extra information to convey.
        • Its name must end with EventHandler.
     */
    public delegate void EventHandler<TEventArgs> (object source, TEventArgs e) where TEventArgs : EventArgs;

    // (prior to C# 2.0)
    public delegate void PriceChangedHandler (object sender, PriceChangedEventArgs e);

    // The .NET Framework defines a standard pattern for writing events.
    // EventArgs is a base class for conveying information for an event. 
    public class PriceChangedEventArgs : System.EventArgs
    {
        //  It typically exposes data as properties or as read-only fields.

        public readonly decimal LastPrice;
        public readonly decimal NewPrice;
        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    public class Stock
    {
        string symbol;
        decimal price;
        public Stock(string symbol) { this.symbol = symbol; }

        // we use the generic EventHandler delegate
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged != null) PriceChanged(this, e);
            /*
            In multithreaded scenarios
            assign the delegate to a temporary variable before testing and invoking it to avoid a thread-safety error:
           
            var temp = PriceChanged;
            if (temp != null) temp(this, e);

            // from C# 6 with the null-conditional operator
            PriceChanged?.Invoke(this, e);// same functionality
             */
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
        class Test
        {
            static void Main()
            {
                Stock stock = new Stock("THPW");
                stock.Price = 27.10M;
                // Register with the PriceChanged event
                stock.PriceChanged += stock_PriceChanged;
                stock.Price = 31.59M;
                stock.Price = 35.59M;
            }
            static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
            {
                if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                    Console.WriteLine("Alert, 10% stock price increase!");
            }
        }

    }


}
