using Core.Models;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllAsync();
        Task AddAsync(TodoItem item);
        Task DeleteAsync(int id);
        Task ToggleCompleteAsync(int id);
    }
}
