using EasyStore.Data;
using EasyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add-produto")]
        public JsonResult AddProduto([FromBody] ProdutoRequest request)
        {
            if (string.IsNullOrEmpty(request.Codigo) || request.Quantidade <= 0)
            {
                return new JsonResult(new { mensagem = "Produto não encontrado ou quantidade inválida." });
            }

            var produto = _context.Produtos.FirstOrDefault(p => p.Codigo == request.Codigo);
            if (produto == null)
            {
                return new JsonResult(new { mensagem = "Produto não encontrado." });
            }

            decimal valorTotal = produto.Preco * request.Quantidade;

            return new JsonResult(new
            {
                nome = produto.Nome,
                valor = valorTotal
            });
        }

        [HttpPost("finalizar-compra")]
        public JsonResult FinalizePurchase([FromBody] FinalizePurchaseRequest request)
        {
            try
            {
                // Aqui você pode pegar o ID do usuário autenticado
                var userId = "1"; // Por enquanto, o ID está fixo (adicione a lógica de autenticação)

                // Criar a venda
                var venda = new Venda
                {
                    UsuarioId = userId,
                    DataVenda = DateTime.Now,
                    MetodoPagamento = request.MetodoPagamento,
                    ValorTotal = request.Total
                };
                _context.Vendas.Add(venda);
                _context.SaveChanges();

                // Associar os produtos vendidos
                foreach (var produto in request.Produtos)
                {
                    var produtoVenda = new ProdutoVenda
                    {
                        VendaId = venda.VendaId,
                        ProdutoId = _context.Produtos.FirstOrDefault(p => p.Nome == produto.Nome)?.ProdutoId ?? 0,
                        Quantidade = produto.Quantidade,
                        ValorUnitario = produto.Valor
                    };
                    _context.ProdutoVendas.Add(produtoVenda);
                }
                _context.SaveChanges();

                return new JsonResult(new { sucesso = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }

    public class ProdutoRequest
    {
        public string? Codigo { get; set; }
        public int Quantidade { get; set; }
    }

    public class FinalizePurchaseRequest
    {
        public string? MetodoPagamento { get; set; }
        public decimal Total { get; set; }
        public List<ProdutoVendaRequest>? Produtos { get; set; }
    }

    public class ProdutoVendaRequest
    {
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
