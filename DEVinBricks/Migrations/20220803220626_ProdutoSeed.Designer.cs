﻿// <auto-generated />
using System;
using DEVinBricks.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEVinBricks.Migrations
{
    [DbContext(typeof(DEVinBricksContext))]
    [Migration("20220803220626_ProdutoSeed")]
    partial class ProdutoSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Comprador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("Compradores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            CPF = "34602022030",
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDeNascimento = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "comprador1@comprador.com.br",
                            Nome = "Comprador 1",
                            Telefone = "1234567891",
                            UsuarioInclusaoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            CPF = "13574152060",
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDeNascimento = new DateTime(2000, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "comprador2@comprador.com.br",
                            Nome = "Comprador 2",
                            Telefone = "1234567892",
                            UsuarioInclusaoId = 1
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            CPF = "57394817083",
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDeNascimento = new DateTime(2000, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "comprador3@comprador.com.br",
                            Nome = "Comprador 3",
                            Telefone = "1234567893",
                            UsuarioInclusaoId = 1
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            CPF = "39921234056",
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDeNascimento = new DateTime(2000, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "comprador4@comprador.com.br",
                            Nome = "Comprador 4",
                            Telefone = "1234567894",
                            UsuarioInclusaoId = 1
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            CPF = "80202128091",
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataDeNascimento = new DateTime(2000, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "comprador5@comprador.com.br",
                            Nome = "Comprador 5",
                            Telefone = "1234567895",
                            UsuarioInclusaoId = 1
                        });
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            Id = 11,
                            Nome = "Rondônia",
                            UF = "RO"
                        },
                        new
                        {
                            Id = 12,
                            Nome = "Acre",
                            UF = "AC"
                        },
                        new
                        {
                            Id = 13,
                            Nome = "Amazonas",
                            UF = "AM"
                        },
                        new
                        {
                            Id = 14,
                            Nome = "Roraima",
                            UF = "RR"
                        },
                        new
                        {
                            Id = 15,
                            Nome = "Pará",
                            UF = "PA"
                        },
                        new
                        {
                            Id = 16,
                            Nome = "Amapá",
                            UF = "AP"
                        },
                        new
                        {
                            Id = 17,
                            Nome = "Tocantins",
                            UF = "TO"
                        },
                        new
                        {
                            Id = 21,
                            Nome = "Maranhão",
                            UF = "MA"
                        },
                        new
                        {
                            Id = 22,
                            Nome = "Piauí",
                            UF = "PI"
                        },
                        new
                        {
                            Id = 23,
                            Nome = "Ceará",
                            UF = "CE"
                        },
                        new
                        {
                            Id = 24,
                            Nome = "Rio Grande do Norte",
                            UF = "RN"
                        },
                        new
                        {
                            Id = 25,
                            Nome = "Paraíba",
                            UF = "PB"
                        },
                        new
                        {
                            Id = 26,
                            Nome = "Pernanmbuco",
                            UF = "PE"
                        },
                        new
                        {
                            Id = 27,
                            Nome = "Alagoas",
                            UF = "AL"
                        },
                        new
                        {
                            Id = 28,
                            Nome = "Sergipe",
                            UF = "SE"
                        },
                        new
                        {
                            Id = 29,
                            Nome = "Bahia",
                            UF = "BA"
                        },
                        new
                        {
                            Id = 31,
                            Nome = "Minas Gerais",
                            UF = "MG"
                        },
                        new
                        {
                            Id = 32,
                            Nome = "Espírito Santo",
                            UF = "ES"
                        },
                        new
                        {
                            Id = 33,
                            Nome = "Rio de Janeiro",
                            UF = "RJ"
                        },
                        new
                        {
                            Id = 35,
                            Nome = "São Paulo",
                            UF = "SP"
                        },
                        new
                        {
                            Id = 41,
                            Nome = "Paraná",
                            UF = "PR"
                        },
                        new
                        {
                            Id = 42,
                            Nome = "Santa Catarina",
                            UF = "SC"
                        },
                        new
                        {
                            Id = 43,
                            Nome = "Rio Grande do Sul",
                            UF = "RS"
                        },
                        new
                        {
                            Id = 50,
                            Nome = "Mato Grosso do Sul",
                            UF = "MS"
                        },
                        new
                        {
                            Id = 51,
                            Nome = "Mato Grosso",
                            UF = "MT"
                        },
                        new
                        {
                            Id = 52,
                            Nome = "Goiás",
                            UF = "GO"
                        },
                        new
                        {
                            Id = 53,
                            Nome = "Distrito Federal",
                            UF = "DF"
                        });
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.FreteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Logadouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorFrete")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("Fretes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bairro = "Vasco",
                            Cep = "0123456-789",
                            Cidade = "Porto Velho",
                            Complemento = "Casa 98",
                            DataDeAlteracao = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5288),
                            DataDeEntrega = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(4922),
                            DataDeInclusao = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5286),
                            EstadoId = 11,
                            Logadouro = "Rua Vasco da Gama, 123",
                            UsuarioAlteracaoId = 1,
                            UsuarioInclusaoId = 1,
                            ValorFrete = 27m
                        },
                        new
                        {
                            Id = 2,
                            Bairro = "T-REX",
                            Cep = "345631-127",
                            Cidade = "Parque Jurassico",
                            Complemento = "Casa 47",
                            DataDeAlteracao = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5705),
                            DataDeEntrega = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5703),
                            DataDeInclusao = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5705),
                            EstadoId = 12,
                            Logadouro = "Rua Dino, 456",
                            UsuarioAlteracaoId = 1,
                            UsuarioInclusaoId = 1,
                            ValorFrete = 53m
                        },
                        new
                        {
                            Id = 3,
                            Bairro = "Acai",
                            Cep = "999999-888",
                            Cidade = "Manaus",
                            Complemento = "Casa 12",
                            DataDeAlteracao = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5709),
                            DataDeEntrega = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5708),
                            DataDeInclusao = new DateTime(2022, 8, 3, 19, 6, 25, 825, DateTimeKind.Local).AddTicks(5708),
                            EstadoId = 13,
                            Logadouro = "Rua do Acai, 789",
                            UsuarioAlteracaoId = 1,
                            UsuarioInclusaoId = 1,
                            ValorFrete = 32m
                        });
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlDaImagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cimento top",
                            Nome = "Cimento",
                            UrlDaImagem = "https://balaroti.vtexassets.com/arquivos/ids/2578293/7278.jpg?v=637508061483670000",
                            UsuarioInclusaoId = 1,
                            Valor = 200m
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Areia top",
                            Nome = "Areia",
                            UrlDaImagem = "https://cdn.leroymerlin.com.br/products/areia_fina_lavada_saco_20kg_grupo_tomino_89851650_636e_300x300.jpg",
                            UsuarioInclusaoId = 1,
                            Valor = 100m
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataDeInclusao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Bitoneira top",
                            Nome = "Bitoneira",
                            UrlDaImagem = "https://a-static.mlcdn.com.br/1500x1500/betoneira-400-litros-com-motor-1-traco-super-csm/palaciodasferramentas/53812/7c7b9bfadd0b3063f3adf248843ed9fa.jpg",
                            UsuarioInclusaoId = 1,
                            Valor = 100000m
                        });
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Admin = true,
                            Ativo = true,
                            DataDeInclusao = new DateTime(2022, 8, 3, 19, 6, 25, 818, DateTimeKind.Local).AddTicks(5746),
                            Email = "admin@gmail.com",
                            Login = "admin",
                            Nome = "Admin",
                            Senha = "admin123",
                            UsuarioInclusaoId = 1
                        });
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.ValorFretePorEstadoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("ValorFreteEstados");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataDeInclusao = new DateTime(2022, 8, 3, 19, 6, 25, 826, DateTimeKind.Local).AddTicks(5173),
                            EstadoId = 42,
                            UsuarioInclusaoId = 1,
                            Valor = 100m
                        });
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompradorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("FreteId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompradorId");

                    b.HasIndex("FreteId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.VendasProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("IdVendaId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProdutoId");

                    b.HasIndex("IdVendaId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("VendasProdutos");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Comprador", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.FreteModel", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Produto", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Usuario", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.ValorFretePorEstadoModel", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Venda", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Comprador", "Comprador")
                        .WithMany()
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinBricks.Repositories.Models.FreteModel", "Frete")
                        .WithMany()
                        .HasForeignKey("FreteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comprador");

                    b.Navigation("Frete");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.VendasProduto", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Produto", "IdProduto")
                        .WithMany()
                        .HasForeignKey("IdProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinBricks.Repositories.Models.Venda", "IdVenda")
                        .WithMany()
                        .HasForeignKey("IdVendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IdProduto");

                    b.Navigation("IdVenda");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });
#pragma warning restore 612, 618
        }
    }
}