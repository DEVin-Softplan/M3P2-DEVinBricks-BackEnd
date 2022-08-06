using System;
using System.Collections.Generic;
using DEVinBricks.Seeds;
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
        public virtual DbSet<FreteModel> Fretes { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<ValorFretePorEstadoModel> ValorFreteEstados { get; set; } = null!;
        public virtual DbSet<VendaModel> Vendas { get; set; } = null!;
        public virtual DbSet<VendaProdutoModel> VendasProdutos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuarioEntityBuilder = modelBuilder.Entity<Usuario>();
            usuarioEntityBuilder.HasOne(prop => prop.UsuarioInclusao).WithMany().OnDelete(DeleteBehavior.NoAction);
            usuarioEntityBuilder.HasIndex(prop => prop.Email).IsUnique();
            usuarioEntityBuilder.HasIndex(prop => prop.Login).IsUnique();
            usuarioEntityBuilder.HasData(UsuarioSeed.Seed);

            var compradorEntityBuilder = modelBuilder.Entity<Comprador>();
            compradorEntityBuilder.HasOne(prop => prop.UsuarioInclusao).WithMany().OnDelete(DeleteBehavior.NoAction);
            compradorEntityBuilder.HasData(CompradorSeed.Seed);

            var freteEntityBuilder = modelBuilder.Entity<FreteModel>();
            freteEntityBuilder.HasOne(prop => prop.UsuarioInclusao).WithMany().OnDelete(DeleteBehavior.NoAction);
            freteEntityBuilder.HasData(FreteSeed.Seed);

            var produtoEntityBuilder = modelBuilder.Entity<Produto>();
            produtoEntityBuilder.HasOne(prop => prop.UsuarioInclusao).WithMany().OnDelete(DeleteBehavior.NoAction);
            produtoEntityBuilder.HasData(ProdutoSeed.Seed);

            var vendaEntityBuilder = modelBuilder.Entity<VendaModel>();
            vendaEntityBuilder.HasOne(prop => prop.UsuarioInclusao).WithMany().OnDelete(DeleteBehavior.NoAction);

            var vendasProdutoEntityBuilder = modelBuilder.Entity<VendasProdutoModel>();
            vendasProdutoEntityBuilder.HasOne(prop => prop.UsuarioInclusao).WithMany().OnDelete(DeleteBehavior.NoAction);

            var valorFreteEstadosModelEntityBuilder = modelBuilder.Entity<ValorFretePorEstadoModel>();
            valorFreteEstadosModelEntityBuilder.HasOne(prop => prop.UsuarioInclusao).WithMany().OnDelete(DeleteBehavior.NoAction);
            valorFreteEstadosModelEntityBuilder.HasData(ValorFretePorEstadoSeed.Seed);

            var estadoEntityBuilder = modelBuilder.Entity<Estado>();
            estadoEntityBuilder.HasData(EstadoSeed.Seed);
        }
    }
}
