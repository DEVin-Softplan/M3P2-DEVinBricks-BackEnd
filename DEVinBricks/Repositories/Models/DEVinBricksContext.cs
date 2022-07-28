using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DEVinBricks.Repositories.Models
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
        public virtual DbSet<ProdutoModel> Produtos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<ValorFretePorEstadoModel> ValorFreteEstados { get; set; } = null!;
        public virtual DbSet<Venda> Vendas { get; set; } = null!;
        public virtual DbSet<VendasProduto> VendasProdutos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprador>().HasOne(prop => prop.UsuarioInclusao).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Frete>().HasOne(prop => prop.UsuarioInclusao).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProdutoModel>().HasOne(prop => prop.UsuarioInclusao).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Venda>().HasOne(prop => prop.UsuarioInclusao).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VendasProduto>().HasOne(prop => prop.UsuarioInclusao).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ValorFretePorEstadoModel>().HasOne(prop => prop.UsuarioInclusao).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
