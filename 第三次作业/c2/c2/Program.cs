using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DateTime datetime = new DateTime();
            Console.WriteLine("在多少秒后播报？");
            int sec = Convert.ToInt32(Console.ReadLine());
            datetime = DateTime.Now.AddSeconds(sec);
            clock.SetAlarmTime(datetime);
            clock.Start();
        }
    }
}