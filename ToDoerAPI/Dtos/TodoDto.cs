namespace ToDoerAPI.Dtos;

public class TodoDto
{
    public string Summary { get; set; }
    public string? Description { get; set; }
    public DateTime? Deadline { get; set; }
    public bool IsComplete { get; set; } = false;
}