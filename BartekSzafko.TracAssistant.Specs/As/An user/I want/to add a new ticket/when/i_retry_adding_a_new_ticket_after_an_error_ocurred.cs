using Machine.Specifications;
using Rhino.Mocks;

namespace BartekSzafko.TracAssistant.Specs.As.An_user.I_want.to_add_a_new_ticket.when
{
    [NamespaceBasedSubject(typeof(when_i_retry_adding_a_new_ticket_after_an_error_ocurred))]
    public class when_i_retry_adding_a_new_ticket_after_an_error_ocurred : AddTicketViewModelContext
    {
        private Establish Context = () => 
            addTicketViewModel.ErrorScreen = true;        

        private Because Of = () => 
            addTicketViewModel.RetryCommand.Execute(null);

        private It should_call_trac_instance_to_add_ticket = () =>
            tracService.AssertWasCalled(x => x.AddTicket(addTicketViewModel.Ticket));
    }
}
