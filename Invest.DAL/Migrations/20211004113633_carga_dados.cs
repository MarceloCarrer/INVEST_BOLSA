using Microsoft.EntityFrameworkCore.Migrations;

namespace Invest.DAL.Migrations
{
    public partial class carga_dados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "a6362d4b-3657-4e2c-9490-2c056ce3fa22");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "a6bb7092-0d6d-4407-a1ca-c4ce138c262b");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "7a72ba2d-3dd1-4565-bda2-001941c65fe5", "1c13bdfc-b609-4c61-91f9-14250f0c662f", "ADMINISTRADOR DO SISTEMA", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "f08b3db1-01b9-4261-bfe9-b6999ac803ad", "3d127946-7098-43bd-a719-f779974c9b34", "USUÁRIO DO SISTEMA", "Usuario", "USUARIO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "7a72ba2d-3dd1-4565-bda2-001941c65fe5");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "f08b3db1-01b9-4261-bfe9-b6999ac803ad");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "a6bb7092-0d6d-4407-a1ca-c4ce138c262b", "903d2cbe-8b60-428d-b10d-f93c9741b4d8", "ADMINISTRADOR DO SISTEMA", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "a6362d4b-3657-4e2c-9490-2c056ce3fa22", "00574b4c-d0b2-4c3e-9431-d9b8b2e4e442", "USUÁRIO DO SISTEMA", "Usuario", "USUARIO" });
        }
    }
}
