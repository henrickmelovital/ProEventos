using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Eventos(Local, DataEvento, Tema, QtdPessoas, Lote, ImagemURL)" +
                "VALUES ('São Paulo', '12/02/2021', 'Angular 11 e .NET 5', 250, '1º', 'foto.png')");

                        migrationBuilder.Sql("INSERT INTO Eventos(Local, DataEvento, Tema, QtdPessoas, Lote, ImagemURL)" +
                "VALUES ('Belo Horizonte', '25/05/2021', 'Angular 15 e .NET 7', 400, '2º', 'foto2.png')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("");
        }
    }
}
