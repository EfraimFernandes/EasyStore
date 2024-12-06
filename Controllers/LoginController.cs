using EasyStore.Models; // Certifique-se de incluir o namespace correto
using Microsoft.AspNetCore.Mvc;
using EasyStore.Data;
using System.Linq;

namespace EasyStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Authenticate(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model); // Retorna para a tela de login com mensagens de validação
            }

            // Busca o usuário no banco de dados
            var user = _context.Usuarios
                .FirstOrDefault(u => u.NomeUsuario == model.Usuario && u.Senha == model.Senha);

            if (user != null)
            {
                // Verifica o tipo de usuário
                if (user.Tipo == "Gerente")
                {
                    return RedirectToAction("Dashboard", "Home"); // Redireciona para Home/Dashboard.cshtml
                }
                else if (user.Tipo == "Vendedor")
                {
                    return RedirectToAction("Vendas", "Home"); // Redireciona para Home/Vendas.cshtml
                }
            }

            // Caso as credenciais sejam inválidas, retorna para a tela de login com mensagem de erro
            TempData["Error"] = "Usuário ou senha inválidos.";
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Index()
        {
            return View("Login"); // Aponta diretamente para Home/Login.cshtml
        }
    }
}
