using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryAudit
{
    public class RegistryService
    {
        private const string AppName = "SettingsAuditApp_Variant23";
        private string _subKeyPath => $@"Software\{AppName}";

        // TODO 1: Создать пользовательскую ветку настроек приложения.
        public void CreateBranch()
        {
            using var key = Registry.CurrentUser.CreateSubKey(_subKeyPath);
            key.SetValue("Theme", "Dark");
            key.SetValue("FontSize", 16, RegistryValueKind.DWord);
            key.SetValue("SchemaVersion", 1, RegistryValueKind.DWord);
            Console.WriteLine("Ветка реестра создана.");
        }
    }
}
