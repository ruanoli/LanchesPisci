using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesPisci.Migrations
{
    public partial class MigracaoIniciall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CatgoriaNome, Descricao) " +
                "VALUES('Normal', 'Deliciosos lanches com ingredientes normais.')");
            migrationBuilder.Sql("INSERT INTO Categorias(CatgoriaNome, Descricao) " +
                "VALUES('Natural', 'Lanches deliciosos com ingredientes saudáveis.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
