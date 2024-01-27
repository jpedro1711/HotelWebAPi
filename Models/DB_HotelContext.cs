using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DB_Hotel
{
    public class DB_HotelContext : DbContext
    {
        public DbSet<Endereco> Endereco {get; set;} = null!;
        public DbSet<Filial> Filial {get; set;} = null!;
        public DbSet<TipoQuarto> TipoQuarto {get; set;} = null!;
        public DbSet<Quarto> Quarto {get; set;} = null!;        
        public DbSet<TipoFuncionario> TipoFuncionario {get; set;} = null!;
        public DbSet<Funcionario> Funcionario {get; set;} = null!;
        public DbSet<TipoPagamento> TipoPagamento {get; set;} = null!;
        public DbSet<NotaFiscal> NotaFiscal {get; set;} = null!;
        public DbSet<Cliente> Cliente {get; set;} = null!;
        public DbSet<Telefone> Telefone {get; set;} = null!;
        public DbSet<Email> Email {get; set;} = null!;
        public DbSet<ContaCliente> ContaCliente {get; set;} = null!;
        public DbSet<Servico> Servico {get; set;} = null!;
        public DbSet<ContaCliente_Servico> ContaCliente_Servico {get; set;} = null!;
        public DbSet<Consumo> Consumo {get; set;} = null!;
        public DbSet<ContaCliente_Consumo> ContaCliente_Consumo {get; set;} = null!;
        public DbSet<Reserva> Reserva {get; set;} = null!;        

        protected override void OnModelCreating(ModelBuilder modelBuilder)            
        { 
            modelBuilder.Entity<Cliente>()
                .HasOne(t => t.Endereco)
                .WithMany(t => t.Clientes)
                .HasForeignKey(t => t.EnderecoCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Consumo>()
                .HasOne(t => t.Filial)
                .WithMany(t => t.Consumos)
                .HasForeignKey(t => t.FilialCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContaCliente_Consumo>()
                .HasOne(t => t.ContaCliente)
                .WithMany(t => t.ContaClienteConsumos)
                .HasForeignKey(t => t.ContaClienteCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContaCliente_Consumo>()
                .HasOne(t => t.Consumo)
                .WithMany(t => t.ContaClienteConsumos)
                .HasForeignKey(t => t.ConsumoCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContaCliente_Consumo>()
                .HasOne(t => t.Funcionario)
                .WithMany(t => t.ContaClienteConsumos)
                .HasForeignKey(t => t.FuncionarioCodigo)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<ContaCliente_Servico>()
                .HasOne(t => t.ContaCliente)
                .WithMany(t => t.ContaClienteServicos)
                .HasForeignKey(t => t.ContaClienteCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContaCliente_Servico>()
                .HasOne(t => t.ContaCliente)
                .WithMany(t => t.ContaClienteServicos)
                .HasForeignKey(t => t.ServicoCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContaCliente_Servico>()
                .HasOne(t => t.Funcionario)
                .WithMany(t => t.ContaClienteServicos)
                .HasForeignKey(t => t.FuncionarioCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Email>()
                .HasOne(t => t.Cliente)
                .WithMany(t => t.Emails)
                .HasForeignKey(t => t.ClienteCodigo)
                .OnDelete(DeleteBehavior.NoAction);            

            modelBuilder.Entity<Filial>()
                .HasOne(t => t.Endereco)
                .WithMany(t => t.Filiais)
                .HasForeignKey(t => t.EnderecoCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Funcionario>()
                .HasOne(t => t.TipoFuncionario)
                .WithMany(t => t.Funcionarios)
                .HasForeignKey(t => t.TipoFuncionarioCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NotaFiscal>()
                .HasOne(t => t.TipoPagamento)
                .WithMany(t => t.NotasFiscais)
                .HasForeignKey(t => t.TipoPagamentoCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Quarto>()
                .HasOne(t => t.TipoQuarto)
                .WithMany(t => t.Quartos)
                .HasForeignKey(t => t.TipoQuartoCodigo)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Reserva>()
                .HasOne(t => t.Filial)
                .WithMany(t => t.Reservas)
                .HasForeignKey(t => t.FilialCodigo)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Reserva>()
                .HasOne(t => t.Quarto)
                .WithMany(t => t.Reservas)
                .HasForeignKey(t => t.QuartoCodigo)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Reserva>()
                .HasOne(t => t.NotaFiscal)
                .WithMany(t => t.Reservas)
                .HasForeignKey(t => t.NotaFiscalCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reserva>()
                .HasOne(t => t.Cliente)
                .WithMany(t => t.Reservas)
                .HasForeignKey(t => t.ClienteCodigo)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Servico>()
                .HasOne(t => t.Filial)
                .WithMany(t => t.Servicos)
                .HasForeignKey(t => t.FilialCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Cliente)
                .WithMany(t => t.Telefones)
                .HasForeignKey(t => t.ClienteCodigo)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TipoQuarto>()
                .HasOne(t => t.Filial)
                .WithMany(t => t.TiposQuartos)
                .HasForeignKey(t => t.FilialCodigo)
                .OnDelete(DeleteBehavior.NoAction);           

            modelBuilder.Entity<TipoQuarto>()            
                .Property(e => e.Valor)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Quarto>()
                .HasKey(e => new { e.QuartoCodigo});


            modelBuilder.Entity<Consumo>()
                .Property(e => e.Valor)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ContaCliente_Consumo>()
                .HasKey(e => new { e.ContaClienteCodigo, e.ConsumoCodigo, e.DataHoraConsumo });          
            
            modelBuilder.Entity<Servico>()
                .Property(e => e.Valor)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ContaCliente_Servico>()
                .HasKey(e => new { e.ContaClienteCodigo, e.ServicoCodigo, e.DataHoraServico });

            modelBuilder.Entity<Reserva>()
             .HasKey(e => new { e.FilialCodigo, e.ReservaCodigo });

            modelBuilder.Entity<Reserva>()                
                .Property(e => e.ValorTotal)
                .HasPrecision(5, 2);
                
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-P8BTRSBI\SQLEXPRESS;Database=DB_HOTEL;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            
        }

    }
}