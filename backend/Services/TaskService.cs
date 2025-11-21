using TaskApi.Models;

namespace TaskApi.Services;

public class TaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public IEnumerable<TaskItem> GetAll() => _tasks;

    public TaskItem Add(string title)
    {
        var t = new TaskItem { Id = _nextId++, Title = title, Completed = false };
        _tasks.Add(t);
        return t;
    }

    public TaskItem? Complete(int id)
    {
        var t = _tasks.FirstOrDefault(x => x.Id == id);
        if (t != null) t.Completed = true;
        return t;
    }

    public bool Delete(int id)
    {
        var t = _tasks.FirstOrDefault(x => x.Id == id);
        return t != null && _tasks.Remove(t);
    }
}

