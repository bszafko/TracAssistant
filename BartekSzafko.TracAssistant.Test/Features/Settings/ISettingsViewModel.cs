using System;
using System.Windows.Input;
using BartekSzafko.TracAssistant.Test.Domain;

namespace BartekSzafko.TracAssistant.Test.Features.Settings
{
    public interface ISettingsViewModel
    {
        bool Confirmation { get; set; }
        ICommand SaveSettingsCommand { get; set; }
        ISettings Settings { get; set; }
    }
}
