using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryAudit
{
    internal class SettingsModel
    {
        public string Theme { get; set; } = "Light";
        public int FontSize { get; set; } = 14;
        public int SchemaVersion { get; set; } = 1;

        // TODO 4: Задать значения по умолчанию.
        public static SettingsModel CreateDefault() => new SettingsModel();
        //TODO 9
        public DateTime LastRunUtc { get; set; } = DateTime.UtcNow;
    }
}
