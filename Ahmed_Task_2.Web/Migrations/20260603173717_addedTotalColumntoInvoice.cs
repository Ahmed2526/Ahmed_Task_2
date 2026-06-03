using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ahmed_Task_2.Web.Migrations
{
    /// <inheritdoc />
    public partial class addedTotalColumntoInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "InvoiceLines",
                type: "decimal(18,5)",
                precision: 18,
                scale: 5,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "InvoiceLines");
        }
    }
}
