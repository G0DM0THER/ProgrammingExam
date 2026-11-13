using RegistryAudit;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;

namespace Variant23;

internal static class Program
{
    private static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Зачётный проект 23: Аудит пользовательских настроек");
        Console.WriteLine(new string('=', 64));

        // Стартовый сценарий нужен для проверки структуры проекта.
        // Реализацию индивидуальных требований выполняйте в ProjectService.
        var service = new ProjectService();
        await service.RunAsync();

        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для завершения.");
        Console.ReadLine();
    }
}

public sealed class ProjectService
{
    private readonly RegistryService _registryService = new();
    private readonly MigrationService _migrationService = new();
    public async Task RunAsync()
    {
        try
        {
            // TODO 1: Создать пользовательскую ветку настроек приложения.
            Console.WriteLine("TODO 1 Создание ветки");
            _registryService.CreateBranch();
            await Task.CompletedTask;

            // TODO 2: Считать и вывести все известные значения.
            Console.WriteLine("\nTODO 2 Чтение данных");
            var (theme, size) = _registryService.ReadSettings();
            // TODO 3: Отличать отсутствие ключа от отсутствия отдельного значения.
            Console.WriteLine("\nTODO 3 Проверка наличия ветки");
            if (!_registryService.DoesBranchExist())
                Console.WriteLine("Ветки нет!");
            else
                Console.WriteLine("Ветка существует.");
            // TODO 4: Задать значения по умолчанию.
            // TODO 5: Добавить версию схемы и проверку совместимости.
            Console.WriteLine("\nTODO 5 Проверка версии схемы");
            _migrationService.CheckCompatibility(1);
            // TODO 6: Реализовать сброс только своей ветки.
            Console.WriteLine("\nTODO 6 Сброс ветки");
            _registryService.ResetBranch();
            Console.WriteLine($"Проверка: {(_registryService.DoesBranchExist() ? "Ветка осталась" : "Ветки нет")}");
            // TODO 7: Обрабатывать ошибки доступа и неверные типы значений.

            // TODO 8: Добавить резервное копирование настроек в JSON.
            Console.WriteLine("\nTODO 8 Бэкап в JSON");
            _registryService.BackupToJson(theme, size);
            // TODO 9: Добавить LastRunUtc.
            Console.WriteLine("\nTODO 9 LastRunUtc");
            Console.WriteLine($"Время запуска: {DateTime.UtcNow}");
            // TODO 10: Реализовать миграцию старой схемы.

            Console.WriteLine("Стартовый проект собран. Реализуйте задания варианта.");
            
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("ОШИБКА: Нет прав на запись в реестр.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ОШИБКА: {ex.Message}");
        }
        await Task.CompletedTask;
    }
}
