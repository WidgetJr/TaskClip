namespace TaskCli.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Done
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
}
