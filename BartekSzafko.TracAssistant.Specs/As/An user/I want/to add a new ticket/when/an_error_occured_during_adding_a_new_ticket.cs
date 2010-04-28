using System;
using Machine.Specifications;
using Rhino.Mocks;

namespace BartekSzafko.TracAssistant.Specs.As.An_user.I_want.to_add_a_new_ticket.when
{
    [Subject("As an user I want to a add new ticket")]
    public class when_an_error_occured_during_adding_a_new_ticket : AddTicketViewModelContext
    {
        private Establish Context =
            () => tracService.Stub(x => x.AddTicket(addTicketViewModel.Ticket)).Throw(new Exception());

        private Because Of = () => addTicketViewModel.AddTicketCommand.Execute(null);

        private It should_allow_openinig_configuration =
            () => addTicketViewModel.OpenConfigurationCommand.CanExecute(null).ShouldBeTrue();

        private It should_allow_retry = () => 
            addTicketViewModel.RetryCommand.CanExecute(null).ShouldBeTrue();

        private It should_display_an_error_screen = () => 
            addTicketViewModel.ErrorScreen.ShouldBeTrue();
    }
}