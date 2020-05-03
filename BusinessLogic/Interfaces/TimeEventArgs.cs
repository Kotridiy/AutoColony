using System;

namespace BusinessLogic.Interfaces
{
    public delegate void TimeEventHandler(object sender, TimeEventArgs args);

    public class TimeEventArgs : EventArgs
    {
        /// <summary>
        /// Virtual time
        /// </summary>
        public DateTime Time { get; }

        public TimeEventArgs(DateTime time) : base()
        {
            Time = time;
        }
    }
}
