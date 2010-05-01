using System;
using System.Windows.Input;
using BartekSzafko.TracAssistant.Domain;

namespace BartekSzafko.TracAssistant.Features.Settings
{
    public interface ISettingsViewModel
    {
        bool Confirmation { get; set; }
        ICommand SaveSettingsCommand { get; set; }
        ISettings Settings { get; set; }
    }
}
