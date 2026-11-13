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
    public async Task RunAsync()
    {
        Console.WriteLine("TODO 1: Создание ветки");
        _registryService.CreateBranch();
        await Task.CompletedTask;
        // TODO 1: Создать пользовательскую ветку настроек приложения.
        // TODO 2: Считать и вывести все известные значения.
        // TODO 3: Отличать отсутствие ключа от отсутствия отдельного значения.
        // TODO 4: Задать значения по умолчанию.
        // TODO 5: Добавить версию схемы и проверку совместимости.
        // TODO 6: Реализовать сброс только своей ветки.
        // TODO 7: Обрабатывать ошибки доступа и неверные типы значений.

        // TODO 8: Добавить резервное копирование настроек в JSON.
        // TODO 9: Добавить LastRunUtc.
        // TODO 10: Реализовать миграцию старой схемы.

        Console.WriteLine("Стартовый проект собран. Реализуйте задания варианта.");
        await Task.CompletedTask;
    }
}
