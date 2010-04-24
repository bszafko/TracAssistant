using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BartekSzafko.TracAssistant.Test.Domain;

namespace BartekSzafko.TracAssistant.Test
{

    public interface ITracService
    {
        void Connect();
        void GetInitData();
        void AddTicket(Ticket ticket);
    }

}
