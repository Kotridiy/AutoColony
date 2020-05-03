using System;

namespace BusinessLogic.Interfaces
{
    public interface ILive
    {
        void Live(DateTime time);
        ILogger Logger { set; }
    }
}
