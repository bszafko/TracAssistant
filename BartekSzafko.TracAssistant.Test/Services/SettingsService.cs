using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using BartekSzafko.TracAssistant.Test.Domain;
using System.IO;

namespace BartekSzafko.TracAssistant.Test
{
    public class SettingsService : ISettingsService
    {
        private string SectionName = "SettingsSection";

        #region ISettingsService Members

        public void Save(ISettings settings)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            SettingsSection section = config.GetSection(SectionName) as SettingsSection;
            if (section != null)
            {
                section.Settings = settings;
            }
            else
            {
                section = new SettingsSection(settings);
                config.Sections.Add(SectionName,section);
            }
            config.Save();
        }

        public ISettings Load()
        {
            SettingsSection section = ConfigurationManager.GetSection(SectionName) as SettingsSection;
            if (section == null)
                return new Settings();
            return section.Settings;
        }

        #endregion
    }

    public class SettingsSection : ConfigurationSection
    {
        public ISettings Settings { get; set; }
        private XmlSerializer serializer;
        
        public SettingsSection()
        {
            serializer = new XmlSerializer(typeof(Settings));
        }

        public SettingsSection(ISettings settings)
        {
            Settings = settings;
            XmlSerializer serializer = new XmlSerializer(typeof(ISettings));
        }

        protected override string SerializeSection(ConfigurationElement parentElement, 
            string name, 
            ConfigurationSaveMode saveMode)
        {
            StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
            XmlTextWriter textWriter = new XmlTextWriter(stringWriter);            
            serializer.Serialize(textWriter, Settings);
            return stringWriter.ToString();
        }

        protected override void DeserializeSection(XmlReader reader)
        {
            Settings = (Settings)serializer.Deserialize(reader);
        }
    }
}
