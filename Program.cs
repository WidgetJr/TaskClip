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

            case "update":
                if (args.Length < 3 || !int.TryParse(args[1], out int updateId))
                {
                    Console.WriteLine("Usage: update <id> \"new description\"");
                    return;
                }
                manager.UpdateTask(tasks, updateId, args[2]);
                break;

            case "delete":
                if (args.Length < 2 || !int.TryParse(args[1], out int deleteId))
                {
                    Console.WriteLine("Usage: delete <id>");
                    return;
                }
                manager.DeleteTask(tasks, deleteId);
                break;

            case "mark":
                if (args.Length < 3 || !int.TryParse(args[1], out int markId))
                {
                    Console.WriteLine("Usage: mark <id> <Pending|InProgress|Done>");
                    return;
                }
                if (!Enum.TryParse<TaskCli.Models.TaskStatus>(args[2], true, out var newStatus))
                {
                    Console.WriteLine("Invalid status. Use: Pending, InProgress, or Done");
                    return;
                }
                manager.MarkTask(tasks, markId, newStatus);
                break;

            default:
                Console.WriteLine($"Unknown command: {command}");
                return;
        }

        manager.SaveTasks(tasks);
    }
}
