using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Net.Security;
using BartekSzafko.TracAssistant.Test.Domain;

namespace BartekSzafko.TracAssistant.Test
{
    public class SettingsViewModel
    {
        public ICommand SaveSettingsCommand { get; set; }
        public bool Confirmation { get; set; }
        public Settings Settings { get; set; }

        public SettingsViewModel(Settings settings)
        {
            this.Settings = settings;
        }
    }
}
