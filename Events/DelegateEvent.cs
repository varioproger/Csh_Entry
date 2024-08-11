namespace Events
{
    //1. 이벤트를 발생시키기 위한 이벤트 핸들러 델리게이트 선언
    //2. 오버라이딩 안됨
    public delegate void MyEventHandler(string message);

    /*
     이벤트 선언 순서

     1.   이벤트를 발생시키기 위한 이벤트 핸들러 델리게이트 선언
     2.   게시자 클래스 선언     
     3.   이벤트 선언 (참고로 이벤트 선언은 값을 전달하는 쪽에서 선언)   
     4.   이벤트 게시자가 있는지 유무 체크    
     5.   구독자 클래스 선언    
     6.   이벤트 사용
     */
    //게시자 클래스 선언
    public class Publisher
    {

        //2. 이벤트 선언 (참고로 이벤트 선언은 값을 전달하는 쪽에서 선언)
        public event MyEventHandler MyEvent;

        public void Do(int number)
        {
            //이벤트 게시자가 있는지 유무 체크
            if (MyEvent != null)
            {
                if (number % 10 == 0)
                {
                   MyEvent("Active" + number); //이벤트 발생
                }
                else
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
    internal class DelegateEvent
    {
         void Main(string[] args)
        {
            Publisher p = new Publisher();
            p.MyEvent += new MyEventHandler(doAction1);
            p.MyEvent += new MyEventHandler(doAction2);

            for (int i = 0; i < 50; i++)
            {
                p.Do(i);
            }
        }

        static public void doAction1(string message)
        {
            Console.WriteLine(message + "1");
        }
        static public void doAction2(string message)
        {
            Console.WriteLine(message + "2");
        }
    }
}
