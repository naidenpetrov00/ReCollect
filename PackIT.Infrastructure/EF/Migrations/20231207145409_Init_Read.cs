using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackIT.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init_Read : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "packing");

            migrationBuilder.CreateTable(
                name: "PackingLists",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Localization = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackingItemReadModel",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    IsPacked = table.Column<bool>(type: "boolean", nullable: false),
                    PackingListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingItemReadModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackingItemReadModel_PackingLists_PackingListId",
                        column: x => x.PackingListId,
                        principalSchema: "packing",
                        principalTable: "PackingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackingItemReadModel_PackingListId",
                schema: "packing",
                table: "PackingItemReadModel",
                column: "PackingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackingItemReadModel",
                schema: "packing");

            migrationBuilder.DropTable(
                name: "PackingLists",
                schema: "packing");
        }
    }
}
