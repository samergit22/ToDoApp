using Application.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private static readonly List<TodoItem> _todos = new();
        private static int _nextId = 1;

        public Task<List<TodoItem>> GetAllAsync()
        {
            return Task.FromResult(_todos.ToList());
        }        

        public Task AddAsync(TodoItem item)
        {
            item.Id = _nextId++;
            _todos.Add(item);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
                _todos.Remove(todo);

            return Task.CompletedTask;
        }

        public Task ToggleCompleteAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
                todo.IsCompleted = !todo.IsCompleted;

            return Task.CompletedTask;
        }
    }
}
