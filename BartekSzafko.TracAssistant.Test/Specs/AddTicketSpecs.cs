using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using BartekSzafko.TracAssistant.Test.Infrastructure;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using BartekSzafko.TracAssistant.Test.Domain;
using BartekSzafko.TracAssistant.Test.Features.AddTicket;
using BartekSzafko.TracAssistant.Test.Features.Settings;

namespace BartekSzafko.TracAssistant.Test
{
    [Subject(typeof(IAddTicketViewModel))]
    public class when_a_user_opens_add_ticket_view : Specification<IAddTicketViewModel>
    {
        private Establish context = () =>
        {
            tracService = An<ITracService>();
            IoC.RegisterInstance<ITracService>(tracService);
            viewManager = IoC.Resolve<IViewManager>();
        };

        private Because of = () => viewManager.Show(typeof(IAddTicketView));

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

    [Subject(typeof(IAddTicketViewModel))]
    public class when_an_error_occurs_during_adding_ticket : AddTicketViewModelContext
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

    [Subject(typeof(IAddTicketViewModel))]
    public class when_user_adds_ticket : AddTicketViewModelContext
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

    public class when_error_occured_and_user_choose_retry : AddTicketViewModelContext
    {
        private Establish Context = () =>
        {
            addTicketViewModel.ErrorScreen = true;
        };

        private Because Of = () => addTicketViewModel.RetryCommand.Execute(null);

        private It should_call_trac_instance_to_add_ticket = () =>
        {
            tracService.AssertWasCalled(x => x.AddTicket(addTicketViewModel.Ticket));
        };
    }

    public class when_error_occured_and_user_choose_to_show_settings : AddTicketViewModelContext
    {
        private Establish Context = () =>
        {
            addTicketViewModel.ErrorScreen = true;
            viewManager = An<IViewManager>();
            IoC.RegisterInstance<IViewManager>(viewManager);
            addTicketViewModel = IoC.Resolve<IAddTicketViewModel>();
        };

        private Because Of = () => addTicketViewModel.OpenConfigurationCommand.Execute(null);

        private It should_open_settings_view = () =>
        {
            viewManager.AssertWasCalled(x => x.Show(typeof(ISettingsView)));
        };

        private static IViewManager viewManager;
    }

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
