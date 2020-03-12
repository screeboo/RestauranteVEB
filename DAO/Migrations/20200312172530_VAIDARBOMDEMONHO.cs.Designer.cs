﻿// <auto-generated />
using System;
using DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAO.Migrations
{
    [DbContext(typeof(RContext))]
    [Migration("20200312172530_VAIDARBOMDEMONHO.cs")]
    partial class VAIDARBOMDEMONHOcs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DTO.BebidaDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<int?>("PedidoDTOID")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .IsUnicode(true);

                    b.HasKey("ID");

                    b.HasIndex("PedidoDTOID");

                    b.ToTable("BEBIDAS");
                });

            modelBuilder.Entity("DTO.IngredienteDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IngredienteDTOID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Quantidade")
                        .HasColumnName("float")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IngredienteDTOID");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("INGREDIENTES");
                });

            modelBuilder.Entity("DTO.PedidoDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BebidaID")
                        .HasColumnType("int");

                    b.Property<string>("NomeNoPedido")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("RefeicaoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BebidaID");

                    b.HasIndex("RefeicaoID");

                    b.ToTable("PEDIDOS");
                });

            modelBuilder.Entity("DTO.RefeicaoDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("PedidoDTOID")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.HasIndex("PedidoDTOID");

                    b.ToTable("REFEICOES");
                });

            modelBuilder.Entity("DTO.UsuarioDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("char(14)")
                        .IsFixedLength(true)
                        .HasMaxLength(14)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Permissao")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("DTO.BebidaDTO", b =>
                {
                    b.HasOne("DTO.PedidoDTO", null)
                        .WithMany("BebidasCollection")
                        .HasForeignKey("PedidoDTOID");
                });

            modelBuilder.Entity("DTO.IngredienteDTO", b =>
                {
                    b.HasOne("DTO.IngredienteDTO", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("IngredienteDTOID");
                });

            modelBuilder.Entity("DTO.PedidoDTO", b =>
                {
                    b.HasOne("DTO.BebidaDTO", "Bebida")
                        .WithMany("PedidoCollection")
                        .HasForeignKey("BebidaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.RefeicaoDTO", "Refeicao")
                        .WithMany("PedidoCollection")
                        .HasForeignKey("RefeicaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.RefeicaoDTO", b =>
                {
                    b.HasOne("DTO.PedidoDTO", null)
                        .WithMany("RefeicoesCollection")
                        .HasForeignKey("PedidoDTOID");
                });
#pragma warning restore 612, 618
        }
    }
}
