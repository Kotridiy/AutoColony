using System;
using System.Threading;

namespace BusinessLogic
{
    public static class Initializer
    {
        public static Thread Initialize(Heart heart, DateTime date)
        {
            return new Thread(() => heart.Start(date));
        }
    }
}
