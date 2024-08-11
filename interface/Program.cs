
/*
    • Interface members are all implicitly abstract. In contrast, a class can provide
      both abstract members and concrete members with implementations

    • A class (or struct) can implement multiple interfaces. In contrast, a class can
      inherit from only a single class, and a struct cannot inherit at all

  Interface members are always implicitly public and cannot declare an access modifier. 
  Implementing an interface means providing a public implementation for all its members
 */
public interface IEnumerator
{
    bool MoveNext();
    object Current { get; }
    void Reset();
}

internal class Countdown : IEnumerator
{
    int count = 11;
    public bool MoveNext() => count-- > 0;
    public object Current => count;
    public void Reset() { throw new NotSupportedException(); }
}



interface I1 { void Foo(); }
interface I2 { int Foo(); }

public class Widget : I1, I2
{
    public void Foo()
    {
        Console.WriteLine("Widget's implementation of I1.Foo");
    }
    // explicitly implemented interface member cannot be marked virtual,
    // nor can it be overridden in the usual manner.
    int I2.Foo()// Explicit Interface Implementation
    {
        Console.WriteLine("Widget's implementation of I2.Foo");
        return 42;
    }
}

// Implementing Interface Members Virtually
public interface IUndoable { void Undo(); }
public class TextBox : IUndoable
{
    // implicitly implemented interface member must be marked virtual or abstract in the base class in order to be overridden.
    public virtual void Undo() => Console.WriteLine("TextBox.Undo");
}
public class RichTextBox : TextBox
{
    public override void Undo() => Console.WriteLine("RichTextBox.Undo");
}

// Reimplementing an Interface in a Subclass
public class TextBox1 : IUndoable
{
    public void Undo() => Console.WriteLine("TextBox.Undo");
}

public class RichTextBox1 : TextBox1, IUndoable
{
    public void Undo() => Console.WriteLine("RichTextBox.Undo");
}

// A better option, however, is to design a base class such that reimplementation will never be required.
// • When explicitly implementing a member, use the following pattern
public class TextBox2 : IUndoable
{
    void IUndoable.Undo() => Undo(); // Calls method below

   
    protected virtual void Undo() => Console.WriteLine("TextBox.Undo");
}
public class RichTextBox2 : TextBox2
{
    protected override void Undo() => Console.WriteLine("RichTextBox.Undo");
}
internal class Program
{
    static void Main(string[] args)
    {
        Widget w = new Widget();
        w.Foo(); // Widget's implementation of I1.Foo
        ((I1)w).Foo(); // Widget's implementation of I1.Foo
        ((I2)w).Foo(); // Widget's implementation of I2.Foo


        RichTextBox r = new RichTextBox();
        r.Undo(); // RichTextBox.Undo
        ((IUndoable)r).Undo(); // RichTextBox.Undo
        ((TextBox)r).Undo(); // RichTextBox.Undo

        // It can, however, be reimplemented.
        // Reimplementation can be a good last resort when subclassing hasn’t been anticipated.
        RichTextBox1 r1 = new RichTextBox1();
        r1.Undo(); // RichTextBox.Undo Case 1
        ((IUndoable)r1).Undo(); // RichTextBox.Undo Case 2
        ((TextBox1)r1).Undo(); // TextBox.Undo Case 3

        // A better option, however, is to design a base class such that reimplementation will never be required.
        // • When implicitly implementing a member, mark it virtual if appropriate.
        RichTextBox2 r2 = new RichTextBox2();
       // r2.Undo(); // RichTextBox.Undo Case 1
        ((IUndoable)r2).Undo(); // RichTextBox.Undo Case 2
       // ((TextBox2)r2).Undo(); // TextBox.Undo Case 3
    }
}
