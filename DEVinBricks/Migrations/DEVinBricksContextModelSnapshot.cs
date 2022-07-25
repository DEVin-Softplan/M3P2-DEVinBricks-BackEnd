﻿// <auto-generated />
using System;
using DEVinBricks.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEVinBricks.Migrations
{
    [DbContext(typeof(DEVinBricksContext))]
    partial class DEVinBricksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("UsuarioInclusaoId")
                        .IsUnique();

                    b.ToTable("Compradores", (string)null);
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

                    b.ToTable("Estados", (string)null);

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

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Frete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId")
                        .IsUnique();

                    b.ToTable("Fretes", (string)null);
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuarioAlteracao")
                        .HasColumnType("int");

                    b.Property<DateTime>("IdUsuarioInclusao")
                        .HasColumnType("datetime2");

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

                    b.HasIndex("UsuarioInclusaoId")
                        .IsUnique();

                    b.ToTable("Produtos", (string)null);
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
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Admin = true,
                            Ativo = true,
                            DataDeInclusao = new DateTime(2022, 7, 24, 10, 51, 9, 914, DateTimeKind.Local).AddTicks(8578),
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

                    b.HasIndex("UsuarioInclusaoId")
                        .IsUnique();

                    b.ToTable("ValorFreteEstados", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataDeInclusao = new DateTime(2022, 7, 24, 10, 51, 9, 917, DateTimeKind.Local).AddTicks(4028),
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

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId")
                        .IsUnique();

                    b.ToTable("Vendas", (string)null);
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

                    b.Property<int?>("UsuarioAlteracaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioInclusaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId")
                        .IsUnique();

                    b.ToTable("VendasProdutos", (string)null);
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Comprador", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("DEVinBricks.Repositories.Models.Comprador", "UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Frete", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("DEVinBricks.Repositories.Models.Frete", "UsuarioInclusaoId")
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
                        .WithOne()
                        .HasForeignKey("DEVinBricks.Repositories.Models.Produto", "UsuarioInclusaoId")
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
                        .WithOne()
                        .HasForeignKey("DEVinBricks.Repositories.Models.ValorFretePorEstadoModel", "UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.Venda", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("DEVinBricks.Repositories.Models.Venda", "UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });

            modelBuilder.Entity("DEVinBricks.Repositories.Models.VendasProduto", b =>
                {
                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("DEVinBricks.Repositories.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("DEVinBricks.Repositories.Models.VendasProduto", "UsuarioInclusaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioInclusao");
                });
#pragma warning restore 612, 618
        }
    }
}
