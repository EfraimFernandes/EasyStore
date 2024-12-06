using EasyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutoVenda> ProdutoVendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = "1", NomeUsuario = "admin", Senha = "123456", Tipo = "Gerente" },
                new Usuario { Id = "2", NomeUsuario = "vendedor", Senha = "123456", Tipo = "Vendedor" }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto { ProdutoId = 1, Codigo = "CAN001", Nome = "Caneta Azul", Quantidade = 100, Preco = 2.50m },
                new Produto { ProdutoId = 2, Codigo = "CAN002", Nome = "Caneta Preta", Quantidade = 50, Preco = 3.00m }
            );
        }
    }
}
