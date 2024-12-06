using EasyStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Landing()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(); // Retorna a view de Login
        }

        public IActionResult Dashboard()
        {
            return View(); // Retorna a view do Dashboard
        }

        public IActionResult Estoque()
        {
            return View(); // Retorna a view de Estoque
        }

        public IActionResult Vendas()
        {
            return View(); // Retorna a view de Vendas
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
