using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using BartekSzafko.TracAssistant.Test.Infrastructure;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using BartekSzafko.TracAssistant.Test.Features.AddTicket;

namespace BartekSzafko.TracAssistant.Test
{
    [Subject(typeof(IBootstrapper))]
    public class when_a_user_starts_application : Specification<IBootstrapper>
    {
        private Establish Context = () =>
            {
                bootstrapper = IoC.Resolve<IBootstrapper>();
                viewManager = An<IViewManager>();
            };

        private Because Of = () => bootstrapper.Startup();

        private It should_display_add_new_ticket_screen = () =>
        {
            viewManager.AssertWasCalled(x => x.Show(typeof(IAddTicketView)));
        };

        private static IBootstrapper bootstrapper;
        private static IViewManager viewManager;
    }
}
