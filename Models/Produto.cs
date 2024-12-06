namespace EasyStore.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Codigo { get; set; }
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public List<ProdutoVenda>? ProdutoVendas { get; set; }
    }
}