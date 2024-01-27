﻿// <auto-generated />
using System;
using DB_Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Migrations
{
    [DbContext(typeof(DB_HotelContext))]
    [Migration("20240127185928_createDatabase")]
    partial class createDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DB_Hotel.Cliente", b =>
                {
                    b.Property<int>("ClienteCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteCodigo"));

                    b.Property<int>("EnderecoCodigo")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidade")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClienteCodigo");

                    b.HasIndex("EnderecoCodigo");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("DB_Hotel.Consumo", b =>
                {
                    b.Property<int>("ConsumoCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsumoCodigo"));

                    b.Property<int?>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int>("FilialCodigo")
                        .HasColumnType("int");

                    b.Property<decimal?>("Valor")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("ConsumoCodigo");

                    b.HasIndex("FilialCodigo");

                    b.ToTable("Consumo");
                });

            modelBuilder.Entity("DB_Hotel.ContaCliente", b =>
                {
                    b.Property<int>("ContaClienteCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContaClienteCodigo"));

                    b.Property<int>("ClienteCodigo")
                        .HasColumnType("int");

                    b.HasKey("ContaClienteCodigo");

                    b.HasIndex("ClienteCodigo");

                    b.ToTable("ContaCliente");
                });

            modelBuilder.Entity("DB_Hotel.ContaCliente_Consumo", b =>
                {
                    b.Property<int>("ContaClienteCodigo")
                        .HasColumnType("int");

                    b.Property<int>("ConsumoCodigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraConsumo")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioCodigo")
                        .HasColumnType("int");

                    b.Property<bool?>("ServicoQuarto")
                        .HasColumnType("bit");

                    b.HasKey("ContaClienteCodigo", "ConsumoCodigo", "DataHoraConsumo");

                    b.HasIndex("ConsumoCodigo");

                    b.HasIndex("FuncionarioCodigo");

                    b.ToTable("ContaCliente_Consumo");
                });

            modelBuilder.Entity("DB_Hotel.ContaCliente_Servico", b =>
                {
                    b.Property<int>("ContaClienteCodigo")
                        .HasColumnType("int");

                    b.Property<int>("ServicoCodigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraServico")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioCodigo")
                        .HasColumnType("int");

                    b.HasKey("ContaClienteCodigo", "ServicoCodigo", "DataHoraServico");

                    b.HasIndex("FuncionarioCodigo");

                    b.HasIndex("ServicoCodigo");

                    b.ToTable("ContaCliente_Servico");
                });

            modelBuilder.Entity("DB_Hotel.Email", b =>
                {
                    b.Property<int>("EmailCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmailCodigo"));

                    b.Property<int>("ClienteCodigo")
                        .HasColumnType("int");

                    b.Property<string>("EnderecoEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmailCodigo");

                    b.HasIndex("ClienteCodigo");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("DB_Hotel.Endereco", b =>
                {
                    b.Property<int>("EnderecoCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoCodigo"));

                    b.Property<string>("Bairro")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pais")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rua")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EnderecoCodigo");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("DB_Hotel.Filial", b =>
                {
                    b.Property<int>("FilialCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilialCodigo"));

                    b.Property<int>("EnderecoCodigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("QtdEstrelas")
                        .HasColumnType("int");

                    b.HasKey("FilialCodigo");

                    b.HasIndex("EnderecoCodigo");

                    b.ToTable("Filial");
                });

            modelBuilder.Entity("DB_Hotel.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioCodigo"));

                    b.Property<int>("FilialCodigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TipoFuncionarioCodigo")
                        .HasColumnType("int");

                    b.HasKey("FuncionarioCodigo");

                    b.HasIndex("FilialCodigo");

                    b.HasIndex("TipoFuncionarioCodigo");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("DB_Hotel.NotaFiscal", b =>
                {
                    b.Property<int>("NotaFiscalCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotaFiscalCodigo"));

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("TipoPagamentoCodigo")
                        .HasColumnType("int");

                    b.HasKey("NotaFiscalCodigo");

                    b.HasIndex("TipoPagamentoCodigo");

                    b.ToTable("NotaFiscal");
                });

            modelBuilder.Entity("DB_Hotel.Quarto", b =>
                {
                    b.Property<int>("QuartoCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuartoCodigo"));

                    b.Property<int?>("CapacidadeMax")
                        .HasColumnType("int");

                    b.Property<bool?>("CapacidadeOpc")
                        .HasColumnType("bit");

                    b.Property<int>("FilialCodigo")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("TipoQuartoCodigo")
                        .HasColumnType("int");

                    b.HasKey("QuartoCodigo");

                    b.HasIndex("FilialCodigo");

                    b.HasIndex("TipoQuartoCodigo");

                    b.ToTable("Quarto");
                });

            modelBuilder.Entity("DB_Hotel.Reserva", b =>
                {
                    b.Property<int>("FilialCodigo")
                        .HasColumnType("int");

                    b.Property<int>("ReservaCodigo")
                        .HasColumnType("int");

                    b.Property<bool?>("Cancelada")
                        .HasColumnType("bit");

                    b.Property<int>("ClienteCodigo")
                        .HasColumnType("int");

                    b.Property<bool?>("CobrancaDiaria")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaFiscalCodigo")
                        .HasColumnType("int");

                    b.Property<int>("QuartoCodigo")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorTotal")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("FilialCodigo", "ReservaCodigo");

                    b.HasIndex("ClienteCodigo");

                    b.HasIndex("NotaFiscalCodigo");

                    b.HasIndex("QuartoCodigo");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("DB_Hotel.Servico", b =>
                {
                    b.Property<int>("ServicoCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicoCodigo"));

                    b.Property<int?>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int>("FilialCodigo")
                        .HasColumnType("int");

                    b.Property<decimal?>("Valor")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("ServicoCodigo");

                    b.HasIndex("FilialCodigo");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("DB_Hotel.Telefone", b =>
                {
                    b.Property<int>("TelefoneCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TelefoneCodigo"));

                    b.Property<int>("ClienteCodigo")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TelefoneCodigo");

                    b.HasIndex("ClienteCodigo");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("DB_Hotel.TipoFuncionario", b =>
                {
                    b.Property<int>("TipoFuncionarioCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoFuncionarioCodigo"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoFuncionarioCodigo");

                    b.ToTable("TipoFuncionario");
                });

            modelBuilder.Entity("DB_Hotel.TipoPagamento", b =>
                {
                    b.Property<int>("TipoPagamentoCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoPagamentoCodigo"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoPagamentoCodigo");

                    b.ToTable("TipoPagamento");
                });

            modelBuilder.Entity("DB_Hotel.TipoQuarto", b =>
                {
                    b.Property<int>("TipoQuartoCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoQuartoCodigo"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FilialCodigo")
                        .HasColumnType("int");

                    b.Property<decimal?>("Valor")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("TipoQuartoCodigo");

                    b.HasIndex("FilialCodigo");

                    b.ToTable("TipoQuarto");
                });

            modelBuilder.Entity("DB_Hotel.Cliente", b =>
                {
                    b.HasOne("DB_Hotel.Endereco", "Endereco")
                        .WithMany("Clientes")
                        .HasForeignKey("EnderecoCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("DB_Hotel.Consumo", b =>
                {
                    b.HasOne("DB_Hotel.Filial", "Filial")
                        .WithMany("Consumos")
                        .HasForeignKey("FilialCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("DB_Hotel.ContaCliente", b =>
                {
                    b.HasOne("DB_Hotel.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("DB_Hotel.ContaCliente_Consumo", b =>
                {
                    b.HasOne("DB_Hotel.Consumo", "Consumo")
                        .WithMany("ContaClienteConsumos")
                        .HasForeignKey("ConsumoCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DB_Hotel.ContaCliente", "ContaCliente")
                        .WithMany("ContaClienteConsumos")
                        .HasForeignKey("ContaClienteCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DB_Hotel.Funcionario", "Funcionario")
                        .WithMany("ContaClienteConsumos")
                        .HasForeignKey("FuncionarioCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Consumo");

                    b.Navigation("ContaCliente");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("DB_Hotel.ContaCliente_Servico", b =>
                {
                    b.HasOne("DB_Hotel.Funcionario", "Funcionario")
                        .WithMany("ContaClienteServicos")
                        .HasForeignKey("FuncionarioCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DB_Hotel.ContaCliente", "ContaCliente")
                        .WithMany("ContaClienteServicos")
                        .HasForeignKey("ServicoCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DB_Hotel.Servico", "Servico")
                        .WithMany("ContaClienteServicos")
                        .HasForeignKey("ServicoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContaCliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("DB_Hotel.Email", b =>
                {
                    b.HasOne("DB_Hotel.Cliente", "Cliente")
                        .WithMany("Emails")
                        .HasForeignKey("ClienteCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("DB_Hotel.Filial", b =>
                {
                    b.HasOne("DB_Hotel.Endereco", "Endereco")
                        .WithMany("Filiais")
                        .HasForeignKey("EnderecoCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("DB_Hotel.Funcionario", b =>
                {
                    b.HasOne("DB_Hotel.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB_Hotel.TipoFuncionario", "TipoFuncionario")
                        .WithMany("Funcionarios")
                        .HasForeignKey("TipoFuncionarioCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Filial");

                    b.Navigation("TipoFuncionario");
                });

            modelBuilder.Entity("DB_Hotel.NotaFiscal", b =>
                {
                    b.HasOne("DB_Hotel.TipoPagamento", "TipoPagamento")
                        .WithMany("NotasFiscais")
                        .HasForeignKey("TipoPagamentoCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TipoPagamento");
                });

            modelBuilder.Entity("DB_Hotel.Quarto", b =>
                {
                    b.HasOne("DB_Hotel.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB_Hotel.TipoQuarto", "TipoQuarto")
                        .WithMany("Quartos")
                        .HasForeignKey("TipoQuartoCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Filial");

                    b.Navigation("TipoQuarto");
                });

            modelBuilder.Entity("DB_Hotel.Reserva", b =>
                {
                    b.HasOne("DB_Hotel.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DB_Hotel.Filial", "Filial")
                        .WithMany("Reservas")
                        .HasForeignKey("FilialCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DB_Hotel.NotaFiscal", "NotaFiscal")
                        .WithMany("Reservas")
                        .HasForeignKey("NotaFiscalCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DB_Hotel.Quarto", "Quarto")
                        .WithMany("Reservas")
                        .HasForeignKey("QuartoCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Filial");

                    b.Navigation("NotaFiscal");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("DB_Hotel.Servico", b =>
                {
                    b.HasOne("DB_Hotel.Filial", "Filial")
                        .WithMany("Servicos")
                        .HasForeignKey("FilialCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("DB_Hotel.Telefone", b =>
                {
                    b.HasOne("DB_Hotel.Cliente", "Cliente")
                        .WithMany("Telefones")
                        .HasForeignKey("ClienteCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("DB_Hotel.TipoQuarto", b =>
                {
                    b.HasOne("DB_Hotel.Filial", "Filial")
                        .WithMany("TiposQuartos")
                        .HasForeignKey("FilialCodigo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("DB_Hotel.Cliente", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("Reservas");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("DB_Hotel.Consumo", b =>
                {
                    b.Navigation("ContaClienteConsumos");
                });

            modelBuilder.Entity("DB_Hotel.ContaCliente", b =>
                {
                    b.Navigation("ContaClienteConsumos");

                    b.Navigation("ContaClienteServicos");
                });

            modelBuilder.Entity("DB_Hotel.Endereco", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Filiais");
                });

            modelBuilder.Entity("DB_Hotel.Filial", b =>
                {
                    b.Navigation("Consumos");

                    b.Navigation("Reservas");

                    b.Navigation("Servicos");

                    b.Navigation("TiposQuartos");
                });

            modelBuilder.Entity("DB_Hotel.Funcionario", b =>
                {
                    b.Navigation("ContaClienteConsumos");

                    b.Navigation("ContaClienteServicos");
                });

            modelBuilder.Entity("DB_Hotel.NotaFiscal", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("DB_Hotel.Quarto", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("DB_Hotel.Servico", b =>
                {
                    b.Navigation("ContaClienteServicos");
                });

            modelBuilder.Entity("DB_Hotel.TipoFuncionario", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("DB_Hotel.TipoPagamento", b =>
                {
                    b.Navigation("NotasFiscais");
                });

            modelBuilder.Entity("DB_Hotel.TipoQuarto", b =>
                {
                    b.Navigation("Quartos");
                });
#pragma warning restore 612, 618
        }
    }
}