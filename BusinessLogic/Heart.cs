using System;
using System.Threading;

namespace BusinessLogic
{ 
    public class Heart
    {
        const string format = "Heartbeat at {0:d MMM HH:mm}";
        bool stop = false;

        public int Delay { get; private set; }
        public ILogger Logger { get; set; }

        /// <param name="delay">Count of milliseconds that will be equal 0.5 virtual hour</param>
        public Heart(int delay = 1000)
        {
            Delay = delay > 200 ? delay : 200;
        }

        public event TimeEventHandler Heartbeat;

        protected virtual void RaiseHeartbeat(TimeEventArgs args)
        {
            Heartbeat?.Invoke(this, args);
        }

        /// <param name="date"> Virtual date and time </param>
        public void Start(DateTime date)
        {
            stop = false;
            DateTime virtualTime = date;
            DateTime lastHeartbeat = DateTime.Now;
            DateTime lastLog = DateTime.Now;

            Logger?.Log(String.Format(format, date));
            Thread.Sleep(SleepDelay(lastHeartbeat));
            while (!stop)
            {
                lastHeartbeat = DateTime.Now;
                virtualTime = virtualTime.AddHours(0.5);
                if ((DateTime.Now - lastLog).TotalMinutes > 5)
                {
                    Logger?.Log(String.Format(format, virtualTime));
                    lastLog = DateTime.Now;
                }
                RaiseHeartbeat(new TimeEventArgs(virtualTime));
                Thread.Sleep(SleepDelay(lastHeartbeat));
            }
        }

        private int SleepDelay(DateTime lastHeartbeat)
        {
            return (DateTime.Now - lastHeartbeat).TotalMilliseconds < Delay 
                ? Delay - (int)(DateTime.Now - lastHeartbeat).TotalMilliseconds : 1;
        }

        public void Stop()
        {
            stop = true;
        }
    }
}
