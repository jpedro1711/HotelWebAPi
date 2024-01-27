using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class createDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoCodigo);
                });

            migrationBuilder.CreateTable(
                name: "TipoFuncionario",
                columns: table => new
                {
                    TipoFuncionarioCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFuncionario", x => x.TipoFuncionarioCodigo);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamento",
                columns: table => new
                {
                    TipoPagamentoCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamento", x => x.TipoPagamentoCodigo);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnderecoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteCodigo);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_EnderecoCodigo",
                        column: x => x.EnderecoCodigo,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoCodigo");
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    FilialCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QtdEstrelas = table.Column<int>(type: "int", nullable: true),
                    EnderecoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.FilialCodigo);
                    table.ForeignKey(
                        name: "FK_Filial_Endereco_EnderecoCodigo",
                        column: x => x.EnderecoCodigo,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoCodigo");
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    NotaFiscalCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoPagamentoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.NotaFiscalCodigo);
                    table.ForeignKey(
                        name: "FK_NotaFiscal_TipoPagamento_TipoPagamentoCodigo",
                        column: x => x.TipoPagamentoCodigo,
                        principalTable: "TipoPagamento",
                        principalColumn: "TipoPagamentoCodigo");
                });

            migrationBuilder.CreateTable(
                name: "ContaCliente",
                columns: table => new
                {
                    ContaClienteCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCliente", x => x.ContaClienteCodigo);
                    table.ForeignKey(
                        name: "FK_ContaCliente_Cliente_ClienteCodigo",
                        column: x => x.ClienteCodigo,
                        principalTable: "Cliente",
                        principalColumn: "ClienteCodigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteCodigo = table.Column<int>(type: "int", nullable: false),
                    EnderecoEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailCodigo);
                    table.ForeignKey(
                        name: "FK_Email_Cliente_ClienteCodigo",
                        column: x => x.ClienteCodigo,
                        principalTable: "Cliente",
                        principalColumn: "ClienteCodigo");
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    TelefoneCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteCodigo = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.TelefoneCodigo);
                    table.ForeignKey(
                        name: "FK_Telefone_Cliente_ClienteCodigo",
                        column: x => x.ClienteCodigo,
                        principalTable: "Cliente",
                        principalColumn: "ClienteCodigo");
                });

            migrationBuilder.CreateTable(
                name: "Consumo",
                columns: table => new
                {
                    ConsumoCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    FilialCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumo", x => x.ConsumoCodigo);
                    table.ForeignKey(
                        name: "FK_Consumo_Filial_FilialCodigo",
                        column: x => x.FilialCodigo,
                        principalTable: "Filial",
                        principalColumn: "FilialCodigo");
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TipoFuncionarioCodigo = table.Column<int>(type: "int", nullable: false),
                    FilialCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioCodigo);
                    table.ForeignKey(
                        name: "FK_Funcionario_Filial_FilialCodigo",
                        column: x => x.FilialCodigo,
                        principalTable: "Filial",
                        principalColumn: "FilialCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_TipoFuncionario_TipoFuncionarioCodigo",
                        column: x => x.TipoFuncionarioCodigo,
                        principalTable: "TipoFuncionario",
                        principalColumn: "TipoFuncionarioCodigo");
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    ServicoCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    FilialCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.ServicoCodigo);
                    table.ForeignKey(
                        name: "FK_Servico_Filial_FilialCodigo",
                        column: x => x.FilialCodigo,
                        principalTable: "Filial",
                        principalColumn: "FilialCodigo");
                });

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    TipoQuartoCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    FilialCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuarto", x => x.TipoQuartoCodigo);
                    table.ForeignKey(
                        name: "FK_TipoQuarto_Filial_FilialCodigo",
                        column: x => x.FilialCodigo,
                        principalTable: "Filial",
                        principalColumn: "FilialCodigo");
                });

            migrationBuilder.CreateTable(
                name: "ContaCliente_Consumo",
                columns: table => new
                {
                    ContaClienteCodigo = table.Column<int>(type: "int", nullable: false),
                    ConsumoCodigo = table.Column<int>(type: "int", nullable: false),
                    DataHoraConsumo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicoQuarto = table.Column<bool>(type: "bit", nullable: true),
                    FuncionarioCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCliente_Consumo", x => new { x.ContaClienteCodigo, x.ConsumoCodigo, x.DataHoraConsumo });
                    table.ForeignKey(
                        name: "FK_ContaCliente_Consumo_Consumo_ConsumoCodigo",
                        column: x => x.ConsumoCodigo,
                        principalTable: "Consumo",
                        principalColumn: "ConsumoCodigo");
                    table.ForeignKey(
                        name: "FK_ContaCliente_Consumo_ContaCliente_ContaClienteCodigo",
                        column: x => x.ContaClienteCodigo,
                        principalTable: "ContaCliente",
                        principalColumn: "ContaClienteCodigo");
                    table.ForeignKey(
                        name: "FK_ContaCliente_Consumo_Funcionario_FuncionarioCodigo",
                        column: x => x.FuncionarioCodigo,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioCodigo");
                });

            migrationBuilder.CreateTable(
                name: "ContaCliente_Servico",
                columns: table => new
                {
                    ContaClienteCodigo = table.Column<int>(type: "int", nullable: false),
                    ServicoCodigo = table.Column<int>(type: "int", nullable: false),
                    DataHoraServico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCliente_Servico", x => new { x.ContaClienteCodigo, x.ServicoCodigo, x.DataHoraServico });
                    table.ForeignKey(
                        name: "FK_ContaCliente_Servico_ContaCliente_ServicoCodigo",
                        column: x => x.ServicoCodigo,
                        principalTable: "ContaCliente",
                        principalColumn: "ContaClienteCodigo");
                    table.ForeignKey(
                        name: "FK_ContaCliente_Servico_Funcionario_FuncionarioCodigo",
                        column: x => x.FuncionarioCodigo,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioCodigo");
                    table.ForeignKey(
                        name: "FK_ContaCliente_Servico_Servico_ServicoCodigo",
                        column: x => x.ServicoCodigo,
                        principalTable: "Servico",
                        principalColumn: "ServicoCodigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quarto",
                columns: table => new
                {
                    QuartoCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilialCodigo = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    TipoQuartoCodigo = table.Column<int>(type: "int", nullable: false),
                    CapacidadeMax = table.Column<int>(type: "int", nullable: true),
                    CapacidadeOpc = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarto", x => x.QuartoCodigo);
                    table.ForeignKey(
                        name: "FK_Quarto_Filial_FilialCodigo",
                        column: x => x.FilialCodigo,
                        principalTable: "Filial",
                        principalColumn: "FilialCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quarto_TipoQuarto_TipoQuartoCodigo",
                        column: x => x.TipoQuartoCodigo,
                        principalTable: "TipoQuarto",
                        principalColumn: "TipoQuartoCodigo");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    FilialCodigo = table.Column<int>(type: "int", nullable: false),
                    ReservaCodigo = table.Column<int>(type: "int", nullable: false),
                    QuartoCodigo = table.Column<int>(type: "int", nullable: false),
                    ClienteCodigo = table.Column<int>(type: "int", nullable: false),
                    NotaFiscalCodigo = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelada = table.Column<bool>(type: "bit", nullable: true),
                    CobrancaDiaria = table.Column<bool>(type: "bit", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => new { x.FilialCodigo, x.ReservaCodigo });
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_ClienteCodigo",
                        column: x => x.ClienteCodigo,
                        principalTable: "Cliente",
                        principalColumn: "ClienteCodigo");
                    table.ForeignKey(
                        name: "FK_Reserva_Filial_FilialCodigo",
                        column: x => x.FilialCodigo,
                        principalTable: "Filial",
                        principalColumn: "FilialCodigo");
                    table.ForeignKey(
                        name: "FK_Reserva_NotaFiscal_NotaFiscalCodigo",
                        column: x => x.NotaFiscalCodigo,
                        principalTable: "NotaFiscal",
                        principalColumn: "NotaFiscalCodigo");
                    table.ForeignKey(
                        name: "FK_Reserva_Quarto_QuartoCodigo",
                        column: x => x.QuartoCodigo,
                        principalTable: "Quarto",
                        principalColumn: "QuartoCodigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoCodigo",
                table: "Cliente",
                column: "EnderecoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Consumo_FilialCodigo",
                table: "Consumo",
                column: "FilialCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ContaCliente_ClienteCodigo",
                table: "ContaCliente",
                column: "ClienteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ContaCliente_Consumo_ConsumoCodigo",
                table: "ContaCliente_Consumo",
                column: "ConsumoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ContaCliente_Consumo_FuncionarioCodigo",
                table: "ContaCliente_Consumo",
                column: "FuncionarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ContaCliente_Servico_FuncionarioCodigo",
                table: "ContaCliente_Servico",
                column: "FuncionarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ContaCliente_Servico_ServicoCodigo",
                table: "ContaCliente_Servico",
                column: "ServicoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Email_ClienteCodigo",
                table: "Email",
                column: "ClienteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EnderecoCodigo",
                table: "Filial",
                column: "EnderecoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_FilialCodigo",
                table: "Funcionario",
                column: "FilialCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_TipoFuncionarioCodigo",
                table: "Funcionario",
                column: "TipoFuncionarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_TipoPagamentoCodigo",
                table: "NotaFiscal",
                column: "TipoPagamentoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_FilialCodigo",
                table: "Quarto",
                column: "FilialCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_TipoQuartoCodigo",
                table: "Quarto",
                column: "TipoQuartoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteCodigo",
                table: "Reserva",
                column: "ClienteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_NotaFiscalCodigo",
                table: "Reserva",
                column: "NotaFiscalCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_QuartoCodigo",
                table: "Reserva",
                column: "QuartoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_FilialCodigo",
                table: "Servico",
                column: "FilialCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_ClienteCodigo",
                table: "Telefone",
                column: "ClienteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_TipoQuarto_FilialCodigo",
                table: "TipoQuarto",
                column: "FilialCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaCliente_Consumo");

            migrationBuilder.DropTable(
                name: "ContaCliente_Servico");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Consumo");

            migrationBuilder.DropTable(
                name: "ContaCliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "Quarto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoFuncionario");

            migrationBuilder.DropTable(
                name: "TipoPagamento");

            migrationBuilder.DropTable(
                name: "TipoQuarto");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
