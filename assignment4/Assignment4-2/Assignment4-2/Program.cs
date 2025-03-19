using System;
namespace Assignment4_2
{
    //定义委托类型用于Tick和Alarm事件
    public delegate void TickHandler(object sender, EventArgs e);
    public delegate void AlarmHandler(object sender, EventArgs e);
    //定义闹钟类
    public class AlarmClock
    {
        public event TickHandler Tick;
        public event AlarmHandler Alarm;
        private DateTime alarmTime;
        private bool isRunning = false;

        public AlarmClock(DateTime alarmTime)
        {
            this.alarmTime = alarmTime;
        }
        //启动闹钟
        public void Start()
        {
            isRunning = true;
            while(isRunning)
            {
                System.Threading.Thread.Sleep(1000);//用于让当前线程暂停执行指定毫秒数的方法调用
                //触发Tick事件
                OnTick(EventArgs.Empty);
                if(DateTime.Now.Hour==alarmTime.Hour && DateTime.Now.Minute==alarmTime.Minute &&DateTime.Now.Second==alarmTime.Second)
                {
                    OnAlarm(EventArgs.Empty);
                }
            }
        }
        protected virtual void OnTick(EventArgs e)
        {
            Tick?.Invoke(this, e);
        }
        protected virtual void OnAlarm(EventArgs e)
        {
            Alarm?.Invoke(this, e);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入闹钟时间（格式：HH:mm:ss）:");
            var timeInput = Console.ReadLine();
            var alarmTime = DateTime.ParseExact(timeInput, "HH:mm:ss", null);

            AlarmClock clock = new AlarmClock(alarmTime);

            // 注册Tick事件处理方法
            clock.Tick += (sender, e) => Console.WriteLine("嘀嗒... 当前时间：" + DateTime.Now.ToString("HH:mm:ss"));

            // 注册Alarm事件处理方法
            clock.Alarm += (sender, e) => Console.WriteLine("叮叮叮！时间到！");

            Console.WriteLine($"闹钟已设置为 {alarmTime.ToString("HH:mm:ss")}, 正在等待...");

            clock.Start();
        }
    }
}
