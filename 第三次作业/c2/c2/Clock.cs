using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2
{
    class Clock
    {
        DateTime alarmTime = DateTime.Now;

        public delegate void AlarmHandler(object sender, DateTime args);
        public delegate void TickHanlder(object sender, DateTime args);

        public event AlarmHandler OnAlarm;
        public event TickHanlder OnTick;

        public Clock()
        {
            OnAlarm += Alarm;
            OnTick += Tick;
        }

        public void Alarm(object sender, DateTime time)
        {
            Console.WriteLine("您设定的时间" + time + "到了！");
        }

        public void Tick(object sender, DateTime time)
        {
            Console.WriteLine("Tick Tock!  " + time);
        }

        public void Start()
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                OnTick(this, now);
                if (now.ToString() == alarmTime.ToString())
                {
                    OnAlarm(this, alarmTime);
                }
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void SetAlarmTime(DateTime Dtime)
        {
            Console.WriteLine(Dtime);
            alarmTime = Dtime;
        }
    }
}