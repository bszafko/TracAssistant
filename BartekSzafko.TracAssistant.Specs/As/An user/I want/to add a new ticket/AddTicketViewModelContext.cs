using Machine.Specifications.AutoMocking.Rhino;
using BartekSzafko.TracAssistant.Features.AddTicket;
using Machine.Specifications;
using BartekSzafko.TracAssistant.Infrastructure;
using BartekSzafko.TracAssistant.Domain;

namespace BartekSzafko.TracAssistant.Specs
{
    public class AddTicketViewModelContext : Specification<IAddTicketViewModel>
    {
        private Establish Context = () =>
        {
            tracService = An<ITracService>();
            addTicketViewModel = IoC.Resolve<IAddTicketViewModel>();
            addTicketViewModel.Ticket = IoC.Resolve<ITicket>();
        };

        protected static ITracService tracService;
        protected static IAddTicketViewModel addTicketViewModel;
    }
}
