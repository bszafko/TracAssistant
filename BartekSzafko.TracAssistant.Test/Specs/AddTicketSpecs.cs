using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using BartekSzafko.TracAssistant.Test.Infrastructure;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using BartekSzafko.TracAssistant.Test.Domain;

namespace BartekSzafko.TracAssistant.Test
{
    [Subject(typeof(AddTicketViewModel))]
    public class when_a_user_opens_add_ticket_view : Specification<AddTicketViewModel>
    {
        private Establish context = () =>
            {
                tracService = An<ITracService>();
                IoC.RegisterInstance<ITracService>(tracService);
                viewManager = IoC.Resolve<IViewManager>();
            };

        private Because of = () => viewManager.Show(typeof(AddTicketView));

        private It should_connect_to_trac_instance = () =>
        {
            tracService.AssertWasCalled(x => x.Connect());
        };

        private It should_fetch_ticket_initdata = () =>
        {
            tracService.AssertWasCalled(x => x.GetInitData());
        };

        private static IViewManager viewManager;
        private static ITracService tracService;
    }

    [Subject(typeof(AddTicketViewModel))]
    public class when_an_error_occurs_during_adding_ticket : context_for_AddTicketViewModel
    {
        private Establish Context = () =>
        {
            tracService.Stub(x => x.AddTicket(addTicketViewModel.Ticket)).Throw(new Exception());
        };

        private Because Of = () =>
        {
            addTicketViewModel.AddTicketCommand.Execute(null);
        };

        private It should_display_an_error_screen = () =>
        {
            addTicketViewModel.ErrorScreen.ShouldBeTrue();
        };

        private It should_allow_openinig_configuration = () =>
        {
            addTicketViewModel.OpenConfigurationCommand.CanExecute(null).ShouldBeTrue();
        };

        private It should_allow_retry = () =>
        {
            addTicketViewModel.RetryCommand.CanExecute(null).ShouldBeTrue();
        };

    }

    [Subject(typeof(AddTicketViewModel))]
    public class when_user_adds_ticket : context_for_AddTicketViewModel
    {
        private Because Of = () =>
        {
            addTicketViewModel.AddTicketCommand.Execute(null);
        };

        private It should_call_trac_instance_to_add_ticket = () =>
        {
            tracService.AssertWasCalled(x=>x.AddTicket(addTicketViewModel.Ticket));
        };

        private It should_display_confirmation_information = () =>
        {
            addTicketViewModel.ConfirmationInformation.ShouldBeTrue();
        };                
    }

    public class context_for_AddTicketViewModel : Specification<AddTicketViewModel>
    {
        private Establish Context = () =>
        {
            tracService = An<ITracService>();
            addTicketViewModel = new AddTicketViewModel();
            addTicketViewModel.Ticket = new Ticket();
        };

        protected static ITracService tracService;
        protected static AddTicketViewModel addTicketViewModel;
    }
   
}
