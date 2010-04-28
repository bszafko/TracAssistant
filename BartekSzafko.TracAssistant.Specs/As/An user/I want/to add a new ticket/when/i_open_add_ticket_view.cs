using Machine.Specifications.AutoMocking.Rhino;
using Machine.Specifications;
using BartekSzafko.TracAssistant.Features.AddTicket;
using BartekSzafko.TracAssistant.Infrastructure;
using Rhino.Mocks;

namespace BartekSzafko.TracAssistant.Specs.As.An_user.I_want.to_open_new_ticket_view
{
    [NamespaceBasedSubject(typeof(when_i_open_add_a_ticket_view))]
    public class when_i_open_add_a_ticket_view : Specification<IAddTicketViewModel>
    {
        private Establish context = () =>
        {
            tracService = An<ITracService>();
            IoC.RegisterInstance<ITracService>(tracService);
            viewManager = IoC.Resolve<IViewManager>();
        };

        private Because of = () => 
            viewManager.Show(typeof(IAddTicketView));

        private It should_connect_to_trac_instance = () => 
            tracService.AssertWasCalled(x => x.Connect());

        private It should_fetch_ticket_initdata = () => 
            tracService.AssertWasCalled(x => x.GetInitData());

        private static IViewManager viewManager;
        private static ITracService tracService;
    }
}
