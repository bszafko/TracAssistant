using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BartekSzafko.TracAssistant.Test.Domain
{
    public class Ticket
    {
        public DateTime Created { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Reporter { get; set; }

        public string CC { get; set; }

        public string Resolution { get; set; }

        public string Component { get; set; }

        public string Summary { get; set; }

        public string Priority { get; set; }

        public string Keywords { get; set; }

        public string Version { get; set; }

        public string Milestone { get; set; }

        public string Owner { get; set; }

        public string TicketType { get; set; }

        public string Severity { get; set; }

        public string Selection { get; set; }
    }
}
