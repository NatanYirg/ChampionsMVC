using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheChampions.Migrations.Payment
{
    /// <inheritdoc />
    public partial class payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaidCustomer",
                columns: table => new
                {
                    public_key = table.Column<string>(type: "varchar(255)", nullable: false),
                    First_Name = table.Column<string>(type: "longtext", nullable: false),
                    Last_Name = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tx_ref = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidCustomer", x => x.public_key);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaidCustomer");
        }
    }
}
