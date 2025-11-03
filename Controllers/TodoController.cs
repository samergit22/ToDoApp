using Application.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _todoService.GetAllAsync();
            return View(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                TempData["Error"] = "Title cannot be empty.";
                return RedirectToAction("Index");
            }

            var newTodo = new TodoItem
            {
                Title = title,
                IsCompleted = false
            };

            await _todoService.AddAsync(newTodo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            await _todoService.ToggleCompleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
