using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BartekSzafko.TracAssistant.Domain;

namespace BartekSzafko.TracAssistant
{

    public interface ITracService
    {
        void Connect();
        void GetInitData();
        void AddTicket(ITicket ticket);
    }

}
