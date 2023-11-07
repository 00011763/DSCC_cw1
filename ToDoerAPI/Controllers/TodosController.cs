using Microsoft.AspNetCore.Mvc;
using ToDoerAPI.Dtos;
using ToDoerAPI.Models;

namespace ToDoerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : Controller
{
    private readonly TodoContext _context;
    
    public TodosController(TodoContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.TodoItems.ToList());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        var item = _context.TodoItems.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    
    [HttpPost]
    public IActionResult Create(TodoDto todoItemDTO)
    {
        var todoItem = new TodoItem
        {
            Summary = todoItemDTO.Summary,
            Description = todoItemDTO.Description,
            Deadline = todoItemDTO.Deadline,
            IsComplete = todoItemDTO.IsComplete
        };

        _context.TodoItems.Add(todoItem);
        _context.SaveChanges();

        return Ok(todoItem);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(long id, TodoDto todoItemDTO)
    {
        var todoItem = _context.TodoItems.Find(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Summary = todoItemDTO.Summary;
        todoItem.Description = todoItemDTO.Description;
        todoItem.Deadline = todoItemDTO.Deadline;
        todoItem.IsComplete = todoItemDTO.IsComplete;

        _context.TodoItems.Update(todoItem);
        _context.SaveChanges();

        return Ok(todoItem);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePartial(long id, TodoDto todoItemDTO)
    {
        var todoItem = _context.TodoItems.Find(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        if (todoItemDTO.Summary != null)
        {
            todoItem.Summary = todoItemDTO.Summary;
        }

        if (todoItemDTO.Description != null)
        {
            todoItem.Description = todoItemDTO.Description;
        }

        if (todoItemDTO.Deadline != null)
        {
            todoItem.Deadline = todoItemDTO.Deadline;
        }

        if (todoItemDTO.IsComplete != null)
        {
            todoItem.IsComplete = todoItemDTO.IsComplete;
        }

        _context.TodoItems.Update(todoItem);
        _context.SaveChanges();

        return Ok(todoItem);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var todoItem = _context.TodoItems.Find(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        _context.SaveChanges();

        return Ok();
    }
}