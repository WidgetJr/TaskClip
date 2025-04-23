using System.Text.Json;
using TaskCli.Models;

public class TaskManager
{
    private readonly string filePath = "tasks.json";

    public List<TaskItem> LoadTasks()
    {
        try
        {
            if (!File.Exists(filePath))
                return new List<TaskItem>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks: {ex.Message}");
            return new List<TaskItem>();
        }
    }

    public void SaveTasks(List<TaskItem> tasks)
    {
        try
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks: {ex.Message}");
        }
    }

    public void AddTask(List<TaskItem> tasks, string description)
    {
        var newTask = new TaskItem
        {
            Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
            Description = description,
            Status = TaskCli.Models.TaskStatus.Pending
        };

        tasks.Add(newTask);
        Console.WriteLine($"Task added: [{newTask.Id}] {newTask.Description}");
    }

    public void ListTasks(List<TaskItem> tasks)
    {
        if (!tasks.Any())
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"[{task.Id}] {task.Description} - {task.Status}");
        }
    }
    public void UpdateTask(List<TaskItem> tasks, int id, string newDescription)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {id} not found.");
            return;
        }

        task.Description = newDescription;
        Console.WriteLine($"Task [{id}] updated.");
    }

    public void DeleteTask(List<TaskItem> tasks, int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {id} not found.");
            return;
        }

        tasks.Remove(task);
        Console.WriteLine($"Task [{id}] deleted.");
    }

    public void MarkTask(List<TaskItem> tasks, int id, TaskCli.Models.TaskStatus newStatus)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {id} not found.");
            return;
        }

        task.Status = newStatus;
        Console.WriteLine($"Task [{id}] marked as {newStatus}.");
    }

}
