namespace EasyStore.Models
{
    public class ProdutoVenda
    {
        public int ProdutoVendaId { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public Produto? Produto { get; set; }
        public Venda? Venda { get; set; }
    }
}