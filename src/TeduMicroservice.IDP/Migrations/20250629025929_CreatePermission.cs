using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeduMicroservice.IDP.Migrations
{
    /// <inheritdoc />
    public partial class CreatePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83490c19-1f54-4b2a-9d76-e7edb06f5f43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb3bb503-3648-49e3-af7b-e3d56be2837a");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Function = table.Column<string>(type: "varchar(50)", nullable: true),
                    Command = table.Column<string>(type: "varchar(50)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f914a8a-b8e8-4d8d-933d-ef8e0064058c", null, "Admin", "ADMIN" },
                    { "9ab3c4c4-a9ee-4183-ba42-573ce88dc854", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId_Command_Function",
                schema: "Identity",
                table: "Permissions",
                columns: new[] { "RoleId", "Command", "Function" },
                unique: true,
                filter: "[Command] IS NOT NULL AND [Function] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "Identity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f914a8a-b8e8-4d8d-933d-ef8e0064058c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ab3c4c4-a9ee-4183-ba42-573ce88dc854");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83490c19-1f54-4b2a-9d76-e7edb06f5f43", null, "Customer", "CUSTOMER" },
                    { "bb3bb503-3648-49e3-af7b-e3d56be2837a", null, "Admin", "ADMIN" }
                });
        }
    }
}
