using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryAudit
{
    public class MigrationService
    {
        private const int CurrentSchemaVersion = 2;

        // TODO 5: Добавить версию схемы и проверку совместимости.
        public void CheckCompatibility(int versionInRegistry)
        {
            if (versionInRegistry == CurrentSchemaVersion)
                Console.WriteLine($"Версия {versionInRegistry} актуальна.");
            else if (versionInRegistry < CurrentSchemaVersion)
                Console.WriteLine($"Версия {versionInRegistry} устарела. Нужна миграция.");
            else
                Console.WriteLine($"ошибка: Версия в реестре ({versionInRegistry}) новее программы!");
        }

    }
}
