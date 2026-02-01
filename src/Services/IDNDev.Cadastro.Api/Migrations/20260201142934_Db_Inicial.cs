using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDNDev.Cadastro.Api.Migrations
{
    /// <inheritdoc />
    public partial class Db_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cadastros");

            migrationBuilder.CreateTable(
                name: "Pessoas",
                schema: "Cadastros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas",
                schema: "Cadastros");
        }
    }
}
