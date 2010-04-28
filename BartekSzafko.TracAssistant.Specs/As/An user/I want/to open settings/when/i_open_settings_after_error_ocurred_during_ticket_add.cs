using Machine.Specifications;
using BartekSzafko.TracAssistant.Infrastructure;
using BartekSzafko.TracAssistant.Features.AddTicket;
using Rhino.Mocks;
using BartekSzafko.TracAssistant.Features.Settings;

namespace BartekSzafko.TracAssistant.Specs.As.An_user.I_want.to_open_settings
{
    [NamespaceBasedSubject(typeof(when_i_open_settings_after_error_ocurred_during_ticket_add))]
    public class when_i_open_settings_after_error_ocurred_during_ticket_add : AddTicketViewModelContext
    {
        private Establish Context = () =>
        {
            addTicketViewModel.ErrorScreen = true;
            viewManager = An<IViewManager>();
            IoC.RegisterInstance<IViewManager>(viewManager);
            addTicketViewModel = IoC.Resolve<IAddTicketViewModel>();
        };

        private Because Of = () => 
            addTicketViewModel.OpenConfigurationCommand.Execute(null);

        private It should_open_settings_view = () => 
            viewManager.AssertWasCalled(x => x.Show(typeof(ISettingsView)));

        private static IViewManager viewManager;
    }
}
