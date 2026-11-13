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

        // TODO 2: Считать и вывести все известные значения.
        public (string Theme, int FontSize) ReadSettings()
        {
            using var key = Registry.CurrentUser.OpenSubKey(_subKeyPath);
            if (key == null) throw new Exception("Ветка не найдена!");

            string theme = key.GetValue("Theme") as string ?? "Неизвестно";
            int fontSize = (int)key.GetValue("FontSize", 0);

            Console.WriteLine($"Прочитано: Theme={theme}, FontSize={fontSize}");
            return (theme, fontSize);
        }

        // TODO 3: Отличать отсутствие ключа от отсутствия отдельного значения.
        public bool DoesBranchExist()
        {
            using var key = Registry.CurrentUser.OpenSubKey(_subKeyPath);
            return key != null;
        }
    }
}
