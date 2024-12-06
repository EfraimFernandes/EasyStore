using EasyStore.Data;
using EasyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

[Route("Dashboard")]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var vendas = new List<object>();

        // Chama a stored procedure para pegar as vendas dos últimos 15 dias
        using (var connection = _context.Database.GetDbConnection())
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "EXEC GetVendasUltimos14Dias";
                command.CommandType = CommandType.Text;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendas.Add(new
                        {
                            Data = reader.GetDateTime(0).ToString("yyyy-MM-dd"),
                            TotalVendas = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1)
                        });
                    }
                }
            }
        }

        return Json(vendas); // Retorna os dados como JSON para o frontend
    }
}