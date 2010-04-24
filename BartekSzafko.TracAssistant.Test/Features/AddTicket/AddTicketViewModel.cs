using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BartekSzafko.TracAssistant.Test.Domain;

namespace BartekSzafko.TracAssistant.Test
{
    public class AddTicketViewModel
    {
        public ICommand AddTicketCommand { get; set; }
        public ICommand OpenConfigurationCommand { get; set; }
        public bool ConfirmationInformation { get; set; }
        public bool ErrorScreen { get; set; }
        public Ticket Ticket { get; set; }
        public ICommand RetryCommand { get; set; }
    }
}
