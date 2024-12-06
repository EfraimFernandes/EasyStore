namespace EasyStore.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public string? UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public string? MetodoPagamento { get; set; }
        public decimal ValorTotal { get; set; }

        public List<ProdutoVenda>? ProdutoVendas { get; set; }
    }
}