namespace partial
{
    /*
     대규모 프로젝트에서 작업하는 경우 클래스를 개별 파일에 분산하면 여러 프로그래머가 동시에 클래스에 대해 작업할 수 있습니다.
     모든 부분에 public, private 등의 동일한 액세스 가능성이 있어야 합니다.

     모든 부분 형식(Partial Type) 정의에서 클래스 이름 및 제네릭 형식 매개 변수가 일치해야 합니다. 
     부분 메서드(Partial Method)가 포함될 수 있습니다.
         -   접근성 한정자(기본 private 포함)가 없습니다.
         -   void를 반환합니다.
         -   out 매개 변수가 없습니다.
         -   한정자 virtual, override, sealed, new 또는 extern이 없습니다.

     */
    public partial class Coords
    {
        private int x;
        private int y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Coords
    {
        public void PrintCoords()
        {
            Console.WriteLine("Coords: {0},{1}", x, y);
        }
    }

    public partial class Coords
    {
        public void SumtCoords()
        {
            Console.WriteLine("Coords: {0}", x + y);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Coords co = new Coords(1,2);
            co.PrintCoords();
            co.SumtCoords();
        }
    }
}