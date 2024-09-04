using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeUnscripted_Blog.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class HasDataUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password" },
                values: new object[] { "A081407B-FD76-429B-ACA5-1A1158F6B91E", "alireza80heydari@gmail.com", "Alireza Heydari", "AQAAAAIAAYagAAAAEIgjMkrsa4nEbRa+SNWCNu8YRLqvHf8eDBdkgR3cgDhIvO5UuGd06amNpj19nhAtfw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "A081407B-FD76-429B-ACA5-1A1158F6B91E");
        }
    }
}
