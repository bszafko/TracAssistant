using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using BartekSzafko.TracAssistant.Domain;
using BartekSzafko.TracAssistant.Features.Settings;
using BartekSzafko.TracAssistant.Infrastructure;

namespace BartekSzafko.TracAssistant.Specs.As.An_user.I_want.to_save_settings
{
    [NamespaceBasedSubject(typeof(when_i_save_valid_settings))]
    public class when_i_save_valid_settings : Specification<ISettingsViewModel>
    {
        private Establish Context = () =>
        {
            settingsService = An<ISettingsService>();
            settings = IoC.Resolve<ISettings>();
            settingsViewModel = IoC.Resolve<ISettingsViewModel>();
            settingsViewModel.Settings = settings;
        };

        private Because Of = () => 
            settingsViewModel.SaveSettingsCommand.Execute(null);

        private It should_display_confirmation = () => 
            settingsViewModel.Confirmation.ShouldBeTrue();

        private It should_add_settings_to_config_file = () => 
            settingsService.AssertWasCalled(x => x.Save(settings));

        private static ISettings settings;
        private static ISettingsViewModel settingsViewModel;
        private static ISettingsService settingsService;
    }
}
