namespace Tutor2;
public class Asset
{
    public string Name;

    // (Liability => 0 is a shortcut for { get { return 0; } }. 
    public virtual decimal Liability => 0; // Expression-bodied property
}
public class Stock : Asset
{
    public long SharesOwned;
}
public class House : Asset
{
    public decimal Mortgage;
    public override decimal Liability => Mortgage;
}

public class Viila : Asset
{
    public decimal Mortgage;

    /*
     The base keyword is similar to the this keyword
     It serves two essential purposes:
       • Accessing an overridden function member from the subclass
       • Calling a base-class constructor (see the next section)
     */
    public sealed override decimal Liability => base.Liability + Mortgage; // access Asset’s Liability property nonvirtually.
                                                                           // we will always access Asset’s version of this property—regardless of the instance’s actual runtime type.
}

public class Appartment : Asset
{
    public decimal Mortgage;

    // prevent it from being overridden by further subclasses
    public sealed override decimal Liability => Mortgage;
}

//public class Room : Appartment
//{
//    public decimal Mortgage;

//    // prevent it from being overridden by further subclasses
//    public override decimal Liability => Mortgage;
//}


internal class Program
{
    static void Main(string[] args)
    {
        Viila vil= new Viila();
        Console.WriteLine(vil.Liability);
        
    }
}
