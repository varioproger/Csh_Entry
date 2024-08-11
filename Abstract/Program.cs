namespace Abstract
{
    // 순수 가상 함수
    public abstract class Asset
    {
        // Note empty implementation
        public abstract decimal NetValue { get; }
    }

    public class Stock : Asset
    {
        public long SharesOwned;
        public decimal CurrentPrice;
        // Override like a virtual method.
        public override decimal NetValue => CurrentPrice * SharesOwned;
    }

    public class BaseClass
    {
        public virtual void Foo() { Console.WriteLine("BaseClass.Foo"); }
    }
    public class Overrider : BaseClass
    {
        public override void Foo() { Console.WriteLine("Overrider.Foo"); }
    }
    public class Hider : BaseClass
    {
        // you want to hide a member deliberately, in which case you can apply the new modifier to the member in the subclass.
        public new void Foo() { Console.WriteLine("Hider.Foo"); }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Overrider over = new Overrider();
            BaseClass b1 = over;
            over.Foo(); // Overrider.Foo
            b1.Foo(); // Overrider.Foo

            Hider h = new Hider();
            BaseClass b2 = h;
            h.Foo(); // Hider.Foo
            b2.Foo(); // BaseClass.Foo
        }
    }
}