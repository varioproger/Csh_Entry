namespace eventargs
{
    // 이벤트 데이터를 포함하는 클래스의 기본 클래스를 나타내며 이벤트 데이터를 포함하지 않는 이벤트에 사용할 값을 제공합니다.
    // 이벤트를 받을때 파라미터로 데이터를 받으려면 EventArg클래스를 상속받아서 원하는 항목을 추가해서 사용이 가능합니다
    public class HongsEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string SimpleData { get; set; }
        public List<Object> Data { get; set; }
    }
    class SomethingEvent
    {
        public event EventHandler eventSomthingClicked;

        public void RaseEvent()
        {
            try
            {
                if (eventSomthingClicked != null)
                {
                    HongsEventArgs nowEventArg = new HongsEventArgs();
                    nowEventArg.Message = "이벤트 클릭";
                    nowEventArg.SimpleData = "NewSimpleData";
                    nowEventArg.Data = new List<object>();
                    nowEventArg.Data.Add(32);
                    nowEventArg.Data.Add("HongJinHyeon");
                    nowEventArg.Data.Add(new List<string>());
                    eventSomthingClicked(null, nowEventArg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            SomethingEvent EventCreator = new SomethingEvent();
            EventCreator.eventSomthingClicked += EventCreator_eventSomthingClicked;
            EventCreator.RaseEvent();
        }
        static void EventCreator_eventSomthingClicked(object sender, EventArgs e)
        {
            try
            {
                HongsEventArgs RecievedEventArg = e as HongsEventArgs;

                Console.WriteLine(RecievedEventArg.SimpleData);
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}