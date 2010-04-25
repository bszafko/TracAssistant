using System;
using System.Windows.Input;
using BartekSzafko.TracAssistant.Test.Domain;

namespace BartekSzafko.TracAssistant.Test.Features.AddTicket
{
    public interface IAddTicketViewModel
    {
        ICommand AddTicketCommand { get; set; }
        bool ConfirmationInformation { get; set; }
        bool ErrorScreen { get; set; }
        ICommand OpenConfigurationCommand { get; set; }
        ICommand RetryCommand { get; set; }
        ITicket Ticket { get; set; }
    }
}
