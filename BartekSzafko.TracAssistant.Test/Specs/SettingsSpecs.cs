using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using BartekSzafko.TracAssistant.Test.Domain;
using BartekSzafko.TracAssistant.Test.Features.Settings;
using BartekSzafko.TracAssistant.Test.Infrastructure;

namespace BartekSzafko.TracAssistant.Test
{
    [Subject("Settings screen")]
    public class when_user_saves_valid_settings : Specification<ISettingsViewModel>
    {
        private Establish Context = () =>
        {
            settingsService = An<ISettingsService>();
            settings = IoC.Resolve<ISettings>();
            settingsViewModel = IoC.Resolve<ISettingsViewModel>();
            settingsViewModel.Settings = settings;
        };

        private Because Of = () => settingsViewModel.SaveSettingsCommand.Execute(null);

        private It should_display_confirmation = () =>
        {
            settingsViewModel.Confirmation.ShouldBeTrue();
        };

        private It should_add_settings_to_config_file = () =>
        {
            settingsService.AssertWasCalled(x => x.Save(settings));
        };

        private static ISettings settings;
        private static ISettingsViewModel settingsViewModel;
        private static ISettingsService settingsService;
    }
}
