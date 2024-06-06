using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaGuard_Dotnet.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    sexo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaRelatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    userId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaRelatorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaRelatorio_TabelaUsuario_userId",
                        column: x => x.userId,
                        principalTable: "TabelaUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelaTanque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    hasFissuras = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    userId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaTanque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaTanque_TabelaUsuario_userId",
                        column: x => x.userId,
                        principalTable: "TabelaUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelaTilapia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    isDoente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tanqueId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaTilapia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaTilapia_TabelaTanque_tanqueId",
                        column: x => x.tanqueId,
                        principalTable: "TabelaTanque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabelaRelatorio_userId",
                table: "TabelaRelatorio",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaTanque_userId",
                table: "TabelaTanque",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaTilapia_tanqueId",
                table: "TabelaTilapia",
                column: "tanqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaRelatorio");

            migrationBuilder.DropTable(
                name: "TabelaTilapia");

            migrationBuilder.DropTable(
                name: "TabelaTanque");

            migrationBuilder.DropTable(
                name: "TabelaUsuario");
        }
    }
}
