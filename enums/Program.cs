namespace enums
{
    public enum BorderSide { Left, Right, Top, Bottom }
    public enum BorderSide2 : byte { Left, Right, Top, Bottom }

    public enum HorizontalAlignment
    {
        Left = BorderSide.Left,
        Right = BorderSide.Right,
        Center
    }

    // Flags Enums
    //  the Flags attribute should always be applied to an enum type when its members are combinable.
    [Flags] // enum require explicitly assigned values
    public enum BorderSides3 { None = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }

    [Flags]
    public enum BorderSides4
    {
        None = 0,
        Left = 1, Right = 2, Top = 4, Bottom = 8,
        LeftRight = Left | Right,
        TopBottom = Top | Bottom,
        All = LeftRight | TopBottom
    }

    // operators that work with enums
    //= == != < > <= >= + - ^ & | ~ += -= ++ -- sizeof

    // enum error check
    // throw new ArgumentException ("Invalid BorderSide: " + side, "side");

    internal class Program
    {
        static void Main(string[] args)
        {
            // To work with combined enum values, you use bitwise operators,\
            BorderSides3 leftRight = BorderSides3.Left | BorderSides3.Right;
            if ((leftRight & BorderSides3.Left) != 0)
                Console.WriteLine("Includes Left"); // Includes Left
            string formatted = leftRight.ToString(); // "Left, Right"
            BorderSides3 s = BorderSides3.Left;
            s |= BorderSides3.Right;
            Console.WriteLine(s == leftRight); // True
            s ^= BorderSides3.Right; // Toggles BorderSides.Right
            Console.WriteLine(s); // Left

        }
    }
}