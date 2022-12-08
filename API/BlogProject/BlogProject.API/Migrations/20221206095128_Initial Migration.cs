using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featuredImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
