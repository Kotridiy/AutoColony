using BusinessLogic.BusinessObjects;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Processors
{
    class WorldProcessor : ILive
    {
        public ILogger Logger { get; set; }

        World World { get; set; }

        public void Live(DateTime time)
        {
            throw new NotImplementedException();
        }
    }
}
