using TaskCli.Models;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: add \"description\" | list");
            return;
        }

        string command = args[0].ToLower();
        var manager = new TaskManager();
        var tasks = manager.LoadTasks();

        switch (command)
        {
            case "add":
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: add \"description\"");
                    return;
                }
                manager.AddTask(tasks, args[1]);
                break;

            case "list":
                manager.ListTasks(tasks);
                break;

            default:
                Console.WriteLine($"Unknown command: {command}");
                return;
        }

        manager.SaveTasks(tasks);
    }
}
