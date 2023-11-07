namespace ToDoerAPI.Models;

public class TodoItem
{
    public long? Id { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public DateTime? Deadline { get; set; }
    public bool IsComplete { get; set; }
}