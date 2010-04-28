using Machine.Specifications;
using BartekSzafko.TracAssistant.Infrastructure;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using BartekSzafko.TracAssistant.Features.AddTicket;

namespace BartekSzafko.TracAssistant.Specs.As.An_user.I_want.to_start_application
{
    [NamespaceBasedSubject(typeof(when_i_start_the_application))]
    public class when_i_start_the_application : Specification<IBootstrapper>
    {
        private Establish Context = () =>
         {
             bootstrapper = IoC.Resolve<IBootstrapper>();
             viewManager = An<IViewManager>();
         };

        private Because Of = () => bootstrapper.Startup();

        private It should_display_add_new_ticket_screen = () => 
            viewManager.AssertWasCalled(x => x.Show(typeof(IAddTicketView)));

        private static IBootstrapper bootstrapper;
        private static IViewManager viewManager;
    }
}
