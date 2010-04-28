using Machine.Specifications;
using Rhino.Mocks;

namespace BartekSzafko.TracAssistant.Specs.As.An_user.I_want.to_add_new_ticket.when
{
    [NamespaceBasedSubject(typeof(when_i_add_a_new_ticket))]
    public class when_i_add_a_new_ticket : AddTicketViewModelContext
    {
        private Because Of = () => 
            addTicketViewModel.AddTicketCommand.Execute(null);

        private It should_call_trac_instance_to_add_ticket = () => 
            tracService.AssertWasCalled(x => x.AddTicket(addTicketViewModel.Ticket));

        private It should_display_confirmation_information = () => 
            addTicketViewModel.ConfirmationInformation.ShouldBeTrue();
    }
}
