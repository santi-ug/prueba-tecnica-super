using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;

namespace TaskApi.Services;

public class TaskService
{
    private readonly AppDbContext _db;

    public TaskService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<TaskItem>> GetAll()
    {
        return await _db.Tasks
            .OrderBy(t => t.id)
            .ToListAsync();
    }

    public async Task<TaskItem> Add(string title)
    {
        var item = new TaskItem
        {
            title = title.Trim(),
            completed = false
        };

        _db.Tasks.Add(item);
        await _db.SaveChangesAsync();

        return item;
    }

    public async Task<TaskItem?> Complete(int id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task == null) return null;

        task.completed = true;
        await _db.SaveChangesAsync();

        return task;
    }

    public async Task<bool> Delete(int id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task == null) return false;

        _db.Tasks.Remove(task);
        await _db.SaveChangesAsync();
        return true;
    }
}

