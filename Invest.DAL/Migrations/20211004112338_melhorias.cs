using Microsoft.EntityFrameworkCore.Migrations;

namespace Invest.DAL.Migrations
{
    public partial class melhorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "6b790c67-9325-4488-944a-0e9f99d3c190");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "d10bd1f7-08b6-4c40-a283-eb7176aef9ff");

            migrationBuilder.DropColumn(
                name: "Imposto",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Lucro",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "LucroLiquido",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "LucroPorc",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "RetornoLiquido",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "TotalValorCompra",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "TotalValorVenda",
                table: "Transacoes");

            migrationBuilder.AlterColumn<bool>(
                name: "Vendido",
                table: "Transacoes",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "ValorVenda",
                table: "Transacoes",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "QtdVenda",
                table: "Transacoes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MesIdVenda",
                table: "Transacoes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DiaVenda",
                table: "Transacoes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnoVenda",
                table: "Transacoes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "a6bb7092-0d6d-4407-a1ca-c4ce138c262b", "903d2cbe-8b60-428d-b10d-f93c9741b4d8", "ADMINISTRADOR DO SISTEMA", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "a6362d4b-3657-4e2c-9490-2c056ce3fa22", "00574b4c-d0b2-4c3e-9431-d9b8b2e4e442", "USUÁRIO DO SISTEMA", "Usuario", "USUARIO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "a6362d4b-3657-4e2c-9490-2c056ce3fa22");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "a6bb7092-0d6d-4407-a1ca-c4ce138c262b");

            migrationBuilder.AlterColumn<bool>(
                name: "Vendido",
                table: "Transacoes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ValorVenda",
                table: "Transacoes",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QtdVenda",
                table: "Transacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MesIdVenda",
                table: "Transacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiaVenda",
                table: "Transacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnoVenda",
                table: "Transacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Imposto",
                table: "Transacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lucro",
                table: "Transacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LucroLiquido",
                table: "Transacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LucroPorc",
                table: "Transacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RetornoLiquido",
                table: "Transacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalValorCompra",
                table: "Transacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalValorVenda",
                table: "Transacoes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "d10bd1f7-08b6-4c40-a283-eb7176aef9ff", "263edf31-0ed1-46bd-84ea-6a099a93ffe7", "Administrador do Sistema", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "6b790c67-9325-4488-944a-0e9f99d3c190", "18abc2e1-9653-4cc3-a4e6-2796abf99a71", "Usuário do Sistema", "Usuario", "USUARIO" });
        }
    }
}
