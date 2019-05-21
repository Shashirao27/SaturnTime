using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerProject
{
    class Program
    {

        static void Main(string[] args)
        {
            TimerStart.Start();
            while (true)
            {
                
                Console.WriteLine(TimerStart.hours.ToString().PadLeft(2,'0') + ":" + TimerStart.mins.ToString().PadLeft(2, '0') + ":" + TimerStart.sec.ToString().PadLeft(2, '0'));
                Console.WriteLine("\a");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }


    }
    public static class TimerStart
    {
        private static Timer timer;
        public static int hours = 12;
        public static int mins = 0;
        public static int sec = 0;
        public static void Start()
        {
            timer = new Timer(500);

            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Enabled = true;
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Increment();

        }
        private static void Increment()
        {
            if (sec == 59)
            {
                sec = 0;
                checkMin();
            }
            else
                sec++;

        }
        private static void checkMin()
        {
            if (mins == 59)
            {
                mins = 0;
                checkHrs();
            }
            else
                mins++;    
        }
        private static void checkHrs()
        {
            if (hours == 23)
                hours = 0;

            else
                hours++;
        }
    }
}
