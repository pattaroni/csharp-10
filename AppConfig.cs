using System;

public class AppConfig
{
    // єдиний екземпляр класу
    private static AppConfig? instance;

    // статичний лічильник створених екземплярів (для перевірки)
    public static int InstanceCount { get; private set; }

    private string language;
    private string colorScheme;
    private int fontSize;

    // приватний конструктор - створити об'єкт через new ззовні неможливо
    private AppConfig()
    {
        language = "uk";
        colorScheme = "Light";
        fontSize = 14;
        InstanceCount++;
    }

    // статична властивість доступу до екземпляра
    public static AppConfig Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AppConfig();
            }
            return instance;
        }
    }

    public string GetLanguage()
    {
        return language;
    }

    public void SetLanguage(string value)
    {
        if (value == "uk" || value == "en")
        {
            language = value;
            Console.WriteLine("Мову змінено на: " + value);
        }
        else
        {
            Console.WriteLine("Непідтримувана мова: " + value);
        }
    }

    public string GetColorScheme()
    {
        return colorScheme;
    }

    public void SetColorScheme(string value)
    {
        if (value == "Light" || value == "Dark")
        {
            colorScheme = value;
            Console.WriteLine("Кольорову схему змінено на: " + value);
        }
        else
        {
            Console.WriteLine("Невідома кольорова схема: " + value);
        }
    }

    public int GetFontSize()
    {
        return fontSize;
    }

    public void SetFontSize(int value)
    {
        if (value >= 8 && value <= 48)
        {
            fontSize = value;
            Console.WriteLine("Розмір шрифту змінено на: " + value);
        }
        else
        {
            Console.WriteLine("Неприпустимий розмір шрифту: " + value + " (дозволено 8-48)");
        }
    }

    public void ShowSettings()
    {
        Console.WriteLine("  Мова: " + language + ", схема: " + colorScheme + ", шрифт: " + fontSize);
    }
}
