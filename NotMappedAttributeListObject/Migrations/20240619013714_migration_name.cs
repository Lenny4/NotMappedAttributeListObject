using Microsoft.EntityFrameworkCore.Migrations;
using System.Text.Json;

#nullable disable

namespace NotMappedAttributeListObject.Migrations
{
    /// <inheritdoc />
    public partial class migration_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FArticles",
                columns: table => new
                {
                    CbMarq = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AR_Ref = table.Column<string>(type: "varchar(19)", unicode: false, maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CBMARQ_F_ARTICLE", x => x.CbMarq);
                });

            migrationBuilder.CreateIndex(
                name: "UKA_F_ARTICLE_AR_Ref",
                table: "FArticles",
                column: "AR_Ref",
                unique: true);

            migrationBuilder.InsertData(
                table: "FArticles",
                columns: new[] { "CbMarq", "AR_Ref" },
                values: new object[,]
                {
                    { 1,"SomeText"},
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FArticles");
        }
    }
}
