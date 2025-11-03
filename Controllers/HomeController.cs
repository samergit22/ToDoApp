using Application.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IErrorService _errorService;

        public HomeController(ILogger<HomeController> logger , IErrorService errorService)
        {
            _logger = logger;
            _errorService = errorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> TestError()
        {
            try
            {
                throw new Exception("Something went wrong!");
            }
            catch (Exception ex)
            {
                await _errorService.LogErrorAsync(new ErrorViewModel
                {
                    RequestId = HttpContext.TraceIdentifier,
                    Message = ex.Message
                });

                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(errorViewModel);
        }
    }
}
