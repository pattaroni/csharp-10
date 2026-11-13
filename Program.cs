using System;

class Program
{
    static void Main()
    {
        Task1To2();
        Task3To4();
    }

    // завдання 1-2
    static void Task1To2()
    {
        Console.WriteLine("Завдання 1-2");

        AppConfig config1 = AppConfig.Instance;
        Console.WriteLine("Налаштування за замовчуванням:");
        config1.ShowSettings();

        config1.SetLanguage("en");
        config1.SetColorScheme("Dark");
        config1.SetFontSize(16);
        config1.SetFontSize(100);

        AppConfig config2 = AppConfig.Instance;
        Console.WriteLine("Налаштування через друге звернення до Instance:");
        config2.ShowSettings();

        PrintThemeFromOtherMethod();

        Console.WriteLine("config1 і config2 - один об'єкт: " + ReferenceEquals(config1, config2));
        Console.WriteLine("Створено екземплярів AppConfig: " + AppConfig.InstanceCount);
        Console.WriteLine();
    }

    // доступ до тих самих налаштувань з іншої частини програми
    static void PrintThemeFromOtherMethod()
    {
        Console.WriteLine("Схема, прочитана в іншому методі: " + AppConfig.Instance.GetColorScheme());
    }

    // завдання 3-4
    static void Task3To4()
    {
        Console.WriteLine("Завдання 3-4");

        SystemState state1 = SystemState.Instance;
        state1.ConnectUser();
        state1.ConnectUser();
        state1.ConnectUser();
        state1.StartProcess("WebServer");
        state1.StartProcess("Database");
        state1.StartProcess("BackupService");
        Console.WriteLine("Стан системи:");
        state1.ShowState();

        SystemState state2 = SystemState.Instance;
        state2.DisconnectUser();
        state2.StopProcess("BackupService");
        state2.UpdateVersion("1.1.0");

        Console.WriteLine("Стан системи через першу змінну після змін через другу:");
        state1.ShowState();

        Console.WriteLine("state1 і state2 - один об'єкт: " + ReferenceEquals(state1, state2));
        Console.WriteLine("Створено екземплярів SystemState: " + SystemState.InstanceCount);
    }
}
