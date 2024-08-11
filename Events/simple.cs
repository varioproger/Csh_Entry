namespace Events
{
    class MyButton
    {
        public string Text;
        // 이벤트 정의
        public event EventHandler Click;

        public void MouseButtonDown()
        {
            if (this.Click != null)
            {
                // 이벤트핸들러들을 호출
                Click(this, EventArgs.Empty);
            }
        }
    }

    internal class simple
    {// 이벤트 사용
        void Main(string[] args)
        {
            MyButton btn = new MyButton();
            // Click 이벤트에 대한 이벤트핸들러로
            // btn_Click 이라는 메서드를 지정함
            btn.Click += new EventHandler(btn_Click);
            btn.Text = "Run";

            btn.MouseButtonDown();
        }
        static void btn_Click(object sender, EventArgs e)
        {
            MyButton obj = (MyButton)sender;
            Console.WriteLine(obj.Text);
        }
    }
}