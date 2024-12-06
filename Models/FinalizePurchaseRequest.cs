namespace EasyStore.Models
{
    public class FinalizePurchaseRequest
    {
        public string MetodoPagamento { get; set; } // Cartão de Crédito, Débito, etc.
        public decimal Total { get; set; } // Total da compra
        public List<ProdutoVendaRequest> Produtos { get; set; } // Produtos vendidos
    }

    public class ProdutoVendaRequest
    {
        public string Nome { get; set; } // Nome do produto
        public int Quantidade { get; set; } // Quantidade do produto
        public decimal Valor { get; set; } // Valor unitário do produto
    }
}