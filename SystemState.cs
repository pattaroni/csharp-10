using System;
using System.Collections.Generic;

public class SystemState
{
    private static SystemState? instance;

    public static int InstanceCount { get; private set; }

    private int connectedUsers;
    private string version;
    private List<string> processes;

    private SystemState()
    {
        connectedUsers = 0;
        version = "1.0.0";
        processes = new List<string>();
        InstanceCount++;
    }

    public static SystemState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SystemState();
            }
            return instance;
        }
    }

    public int GetConnectedUsers()
    {
        return connectedUsers;
    }

    public void ConnectUser()
    {
        connectedUsers++;
    }

    public void DisconnectUser()
    {
        if (connectedUsers > 0)
        {
            connectedUsers--;
        }
    }

    public string GetVersion()
    {
        return version;
    }

    public void UpdateVersion(string newVersion)
    {
        version = newVersion;
        Console.WriteLine("Версію оновлено до " + newVersion);
    }

    // поточна дата і час беруться в момент звернення
    public DateTime GetCurrentDateTime()
    {
        return DateTime.Now;
    }

    public List<string> GetProcesses()
    {
        return new List<string>(processes);
    }

    public void StartProcess(string name)
    {
        if (!processes.Contains(name))
        {
            processes.Add(name);
            Console.WriteLine("Запущено процес: " + name);
        }
    }

    public void StopProcess(string name)
    {
        if (processes.Remove(name))
        {
            Console.WriteLine("Зупинено процес: " + name);
        }
    }

    public void ShowState()
    {
        Console.WriteLine("  Користувачів онлайн: " + connectedUsers);
        Console.WriteLine("  Версія ПЗ: " + version);
        Console.WriteLine("  Дата і час: " + GetCurrentDateTime().ToString("dd.MM.yyyy HH:mm:ss"));
        Console.WriteLine("  Запущені процеси (" + processes.Count + "):");
        foreach (string process in processes)
        {
            Console.WriteLine("    - " + process);
        }
    }
}
