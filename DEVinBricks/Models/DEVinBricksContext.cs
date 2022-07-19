using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class DEVinBricksContext : DbContext
    {
        public DEVinBricksContext()
        {
        }

        public DEVinBricksContext(DbContextOptions<DEVinBricksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comprador> Compradores { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Frete> Fretes { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<ValorFreteEstado> ValorFreteEstados { get; set; } = null!;
        public virtual DbSet<Venda> Vendas { get; set; } = null!;
        public virtual DbSet<VendasProduto> VendasProdutos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
